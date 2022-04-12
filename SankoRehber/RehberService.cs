using SankoRehber.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SankoRehber
{
    internal class RehberService
    {
        RehberEntities db = null;
        public RehberService() {
            if (db == null) {
                db = new RehberEntities();
            }
        }
        public int RehberKaydet(TblRehber rehber)
        {
            db.TblRehber.Add(rehber);
            var res = db.SaveChanges();
            return res;
        }

        public TblRehber GetRehber(int id)
        {
            return db.TblRehber.Find(id);
        }

        public bool RehberGuncelle(TblRehber rehber)
        {

            if (rehber == null)
                return false;

            db.Entry(rehber).State = System.Data.Entity.EntityState.Modified;
            var res = db.SaveChanges();
            return res > 0;
        }

        public bool RehberSil(int id)
        {
            var yoket = GetRehber(id);
            if (yoket == null)
                return false;
            db.TblRehber.Remove(yoket);
            var res = db.SaveChanges();
            return res > 0;
        }

        public List<RehberDTO> listele()
        {
            var veriler = (from x in db.TblRehber
                           select new RehberDTO()
                           {
                               ID = x.ID,
                               Firma_Adı = x.FİRMA_ADI,
                               Lokasyon = x.LOKASYON,
                               Departman = x.DEPARTMAN,
                               Adı = x.ADI,
                               Soyadı = x.SOYADI,
                               Yetkili = x.YETKİLİ,
                               Dahili_1 = x.DAHİLİ_1,
                               Dahili_2 = x.DAHİLİ_2,
                               Dahili_3 = x.DAHİLİ_3,
                               Telefon = x.TELEFON,
                               Cep_Telefonu = x.CEP_TELEFONU,
                               Faks_No = x.FAX_NO
                           });
            return veriler.ToList();
        }
        public List<SifreDTO> sifreListele()
        {
            var degerler = (from x in db.TblUser
                            select new SifreDTO()
                            {
                                ID = x.ID,
                                KULLANICIAD = x.KULLANICIAD,
                                SIFRE = x.SIFRE
                            });
            return degerler.ToList();
        }
        public TblUser GetUser(int id)
        {
            return db.TblUser.Find(id);
        }
        public int UserKyadet(TblUser user)
        {
            db.TblUser.Add(user);
            var res = db.SaveChanges();
            return res;
        }
        public bool UserGuncelle(TblUser user)
        {

            if (user == null)
                return false;

            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            var res = db.SaveChanges();
            return res > 0;
        }
        public bool UserSil(int id)
        {
            var yoket = GetUser(id);
            if (yoket == null)
                return false;
            db.TblUser.Remove(yoket);
            var res = db.SaveChanges();
            return res > 0;
        }
    }
}
