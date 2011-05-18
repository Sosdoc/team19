using System;
using EasyDAL;
using System.IO;
using System.Windows.Forms;
namespace GESCBUS
{
    public class Article 
    {
        private string tmpDescription;
        public string Description
        {
            set
            {
                if (base.Compare(tmpDescription, value) != 0)
                {
                    tmpDescription = value;

                }
            }
            get
            {
                tmpDescription = this.Libelle;
                //tmpDescription = this.Code + " " + this.Libelle;
                return tmpDescription;
            }
        }
        private Decimal tmpCout;
        public new Decimal Cout
        {
            get
            {
                return getCout();
            }

            set
            {
                if (base.Compare(tmpCout, value) != 0)
                {
                    tmpCout = value;

                }
            }
        }
        public Decimal getCout()
        {
            if (this.Nomenclature == null || this.Nomenclature == Guid.Empty)
                return (this.PrixUnitaireAchat);
            else
            {
                decimal CoutTotal = 0;
                foreach (Composition Cmp in this.ObjNomenclature.ListComposition)
                {
                    CoutTotal += Cmp.ObjComposant.Cout * Convert.ToDecimal(Cmp.Quantite);
                }
                return (CoutTotal);
            }
        }
        public DsArticleDetail ToDataSet()
        {
            DsArticleDetail Rt;
            Rt = new DsArticleDetail();
            DsArticleDetail.enteteRow entete = Rt.entete.NewenteteRow();
            DsArticleDetail.detailRow detail;
            //DsArticleDetail.detail1Row detail1;

            entete.code = this.Code;
            entete.libelle = this.Libelle;
            entete.Nomenclature = this.ObjNomenclature.Libelle;
            entete.Gamme = this.ObjGamme.Libelle;

            Rt.entete.AddenteteRow(entete);
            foreach (Composition x in this.ObjNomenclature.ListComposition)
            {
                detail = Rt.detail.NewdetailRow();
                detail.Composant = x.ObjComposant.Libelle;
                detail.Quantite = x.Quantite;
                detail.Rebut = x.Rebut;
                Rt.detail.AdddetailRow(detail);
            }
            //			foreach( Operation x1 in this.ObjGamme.ListOperation)
            //			{
            //				detail1 =Rt.detail1.Newdetail1Row();
            //				detail1.Rang = x1.Rang;
            //				detail1.Operation = x1.Libelle;
            //				Rt.detail1.Adddetail1Row(detail1);
            //				
            //			}

            return Rt;

        }

        public decimal CalculerPPM(DateTime datefin)
        {
            string filtre = "Document.TypeDocument = 'FactureAchat'";
            filtre = filtre + " AND " + "Document.DateDocument <= '" + EasyDAL.Utils.USDate(datefin) + "'";
            filtre = filtre + " AND " + "Article = '" + UID + "'";
            CCDocumentDetail Liste = new CCDocumentDetail();
            Liste.Retrieve(filtre);
            double quantite = 0;
            decimal ttc = 0;
            foreach (DocumentDetail x in Liste)
            {
                ttc += x.MontantTTC;
                quantite += x.Quantite;
            }
            decimal Rt;
            if (quantite != 0)
            {
                Rt = ttc / ((decimal)quantite);
            }
            else
            {
                Rt = 0;
            }
            return Rt;
        }
        public decimal GetCoutMoyenPondere()
        {
            decimal coutpm = 0;
            CCStock ListeStock = new CCStock();
            ListeStock.Retrieve("Article = '" + this.UID + "'");
            if (ListeStock.Count > 0) coutpm = ((Stock)ListeStock[0]).CoutMoyenPondere;
            return coutpm;

        }

        public static CCArticle ListeArticleParFournisseur(string Fourniss)
        {
            CCArticle ListeArticle = new CCArticle();
            CCArticleForn listArticleForn = new CCArticleForn();
            listArticleForn.Retrieve("Fournisseur = '" + Fourniss + "'");
            foreach (ArticleForn ObjArticleForn in listArticleForn)
            {
                ListeArticle.Add(ObjArticleForn.ObjArticle);
            }

            ListeArticle.Sort("Libelle ASC");
            return ListeArticle;
        }

        public static CCArticle ListeArticle()
        {
            CCArticle listearticle = new CCArticle();
            listearticle.Retrieve("", "Libelle ASC");
            return listearticle;
        }
        public Article()
        {

        }
        //		public Article( object[] source)
        //		{
        //			this.Source = source;
        //		}

        public bool ReadUpdateFile(string fichier, string chemin)
        {
            bool ok = true;
            string strUID = "";
            System.IO.StreamWriter strWriter = null;
            strWriter = new StreamWriter(chemin + "\\logArticle.txt", true, System.Text.Encoding.UTF8);
            FileInfo fi = new FileInfo(fichier);
            if (fi.Exists)
            {
                string s; string[] texts, text;
                FileStream fs = new FileStream(fichier, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                s = sr.ReadToEnd();
                if (s != null)
                {
                    CCArticle ListArticle = new CCArticle();
                    ListArticle.Retrieve();
                    texts = s.Split((new string[] { "\r\n" }), 0);
                    for (int i = 0; i < texts.Length - 1; i++)
                    {
                        try
                        {
                            text = texts[i].Split(new char[] { (char)59 });
                            if (text[0].Trim() != string.Empty)
                                ListArticle.ItemFilter = "UID = '" + text[0].Trim().ToString() + "'";
                            strUID = text[0].Trim().ToString();
                            if (ListArticle.Count > 0)
                            {
                                if (text[1].Trim() != string.Empty)
                                {
                                    ListArticle[0].Code = text[1].Trim().ToString();
                                }
                                if (text[2].Trim() != string.Empty)
                                {
                                    ListArticle[0].Libelle = text[2].Trim().ToString();
                                }
                                if (text[3].Trim() != string.Empty)
                                {
                                    ListArticle[0].PrixUnitaireVente = Convert.ToDecimal(text[3].Trim().ToString());
                                }
                                if (text[4].Trim() != string.Empty)
                                {
                                    ListArticle[0].PrixUnitaireAchat = Convert.ToDecimal(text[4].Trim().ToString());
                                }
                                if (text[5].Trim() != string.Empty)
                                {
                                    ListArticle[0].FamilleArticle = new Guid(text[5].Trim().ToString());
                                }
                                if (text[6].Trim() != string.Empty)
                                {
                                    ListArticle[0].Active = Convert.ToBoolean(text[6].Trim().ToString());
                                }
                                try
                                {
                                    ListArticle[0].Persist();
                                }
                                catch (Exception ex)
                                {
                                    strWriter.WriteLine("UID = '" + text[0].Trim().ToString() + "' " + ex.ToString());
                                }
                            }
                            else
                            {
                                Article objArticle = new Article();
                                if (text[0].Trim() != string.Empty)
                                {
                                    objArticle.UID = new Guid(text[0].Trim().ToString());
                                }
                                if (text[1].Trim() != string.Empty)
                                {
                                    objArticle.Code = text[1].Trim().ToString();
                                }
                                if (text[2].Trim() != string.Empty)
                                {
                                    objArticle.Libelle = text[2].Trim().ToString();
                                }
                                if (text[3].Trim() != string.Empty)
                                {
                                    objArticle.PrixUnitaireVente = Convert.ToDecimal(text[3].Trim().ToString());
                                }
                                if (text[4].Trim() != string.Empty)
                                {
                                    objArticle.PrixUnitaireAchat = Convert.ToDecimal(text[4].Trim().ToString());
                                }
                                if (text[5].Trim() != string.Empty)
                                {
                                    objArticle.FamilleArticle = new Guid(text[5].Trim().ToString());
                                }
                                if (text[6].Trim() != string.Empty)
                                {
                                    objArticle.Active = Convert.ToBoolean(text[6].Trim().ToString());
                                }
                                try
                                {
                                    objArticle.Persist();
                                }
                                catch (Exception ex)
                                {
                                    strWriter.WriteLine("UID = '" + text[0].Trim().ToString() + "' " + ex.ToString());
                                }
                            }
                        }
                        catch
                        {
                            ok = false;
                            strWriter.WriteLine("Problème de l'import des Articles " + strUID);
                            strWriter.Flush();
                        }
                    }
                }
                else
                {
                    ok = false;
                }

                sr.Close();
                fs.Close();
            }
            else
            {
                ok = false;
            }
            strWriter.Flush();
            strWriter.WriteLine("Fin de transfer du fichier" + fichier + " : \n " + System.DateTime.Today.ToShortDateString() + " " + System.DateTime.Now.ToShortTimeString());
            strWriter.WriteLine("*********************************************************************************" + " \n ");
            strWriter.Close();
            return ok;
        }
        public void ExportArticle(string NomFichier, DateTime DateDebut, DateTime DateFin)
        {
            StreamWriter swArticle = null;
            swArticle = new StreamWriter(@NomFichier);
            try
            {
                CCArticle ListeArticle = new CCArticle();
                String Filtre = "(DateSaisie >= '" + EasyDAL.Utils.USDate(DateDebut) + "' and DateSaisie < '" + EasyDAL.Utils.USDate(DateFin.AddDays(1)) + "') OR (DateModif >= '" + EasyDAL.Utils.USDate(DateDebut) + "' and DateModif < '" + EasyDAL.Utils.USDate(DateFin.AddDays(1)) + "')";
                ListeArticle.Retrieve(Filtre);
                CCArticleForn ListeArtForn = new CCArticleForn();
                if (ListeArticle.Count > 0)
                {
                    foreach (Article ObjArt in ListeArticle)
                    {
                        //ListArticleForn.Retrieve("Article = '" + ObjArt.UID + "'");
                        //if (ListArticleForn.Count > 0)
                        //{
                        //    foreach (ArticleForn ObjArtForn in ListArticleForn)
                        //    {
                                swArticle.WriteLine(ObjArt.UID.ToString() + ";" + ObjArt.Code + ";" + ObjArt.Libelle + ";" + ObjArt.PrixUnitaireVente + ";" + ObjArt.PrixUnitaireAchat + ";" + ObjArt.FamilleArticle + ";" + ObjArt.Active);
                                //+ ";" + ObjArtForn.Fournisseur
                                //+ ";" + ObjArtForn.DelaiFournisseur
                                //+ ";" + ObjArtForn.QuantiteMultipleFournisseur
                        //        //+ ";" + ObjArtForn.QuantiteMinimaleFournisseur);
                        //    }
                        //}
                        //else
                        //{
                        //    swArticle.WriteLine(ObjArt.UID.ToString() + ";" + ObjArt.Code + ";" + ObjArt.Libelle + ";" + ObjArt.PrixUnitaireVente + ";" + ObjArt.PrixUnitaireAchat + ";" + ObjArt.FamilleArticle + ";" + ObjArt.Active);
                    }
                    swArticle.Close();
                    MessageBox.Show("le nombre des articles exportés est   " + ListeArticle.Count);
                }
                else
                {
                    swArticle.Close();
                    MessageBox.Show("le nombre des articles exportés est 0 ");
                }
            }
            catch (Exception ex)
            {
                swArticle.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        #region IAccessible Members

        bool IAccessible.CanAdd
        {
            get
            {
                return Common.Session.IsAccessible("GESC-Article-A", this.PersistentObjectSession);
            }
        }

        bool IAccessible.CanDelete
        {
            get
            {
                return Common.Session.IsAccessible("GESC-Article-D", this.PersistentObjectSession);
            }
        }

        bool IAccessible.CanEdit
        {
            get
            {
                return Common.Session.IsAccessible("GESC-Article-M", this.PersistentObjectSession);
            }
        }

        bool IAccessible.CanUnValidate
        {
            get
            {
                return Common.Session.IsAccessible("GESC-Article-U", this.PersistentObjectSession);
            }
        }

        bool IAccessible.CanValidate
        {
            get
            {
                return Common.Session.IsAccessible("GESC-Article-V", this.PersistentObjectSession);
            }
        }

        #endregion
    }

    public class CCArticle : AbstractCCArticle
    {
        public CCArticle()
        {

        }
        public new CCArticle GetChanges()
        {
            return (CCArticle)base.GetChanges();
        }
        public new DescriptionForUser getDescriptionForUser()
        {
            DescriptionForUser Rt;
            Rt = base.getDescriptionForUser();
            Rt.Name = "Article pour GESC ou GPAO";
            Rt.ExportablePropertiesDescription["Code"].Description = "Référence";
            Rt.ExportablePropertiesDescription.Sort("Description");
            return Rt;
        }
    }
}

