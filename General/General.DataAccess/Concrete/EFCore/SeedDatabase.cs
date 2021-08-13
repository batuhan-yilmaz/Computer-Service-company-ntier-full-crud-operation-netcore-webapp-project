using General.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.DataAccess.Concrete.EFCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new Context();
            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if(context.ControlCenters.Count()==0)
                {
                    context.ControlCenters.AddRange(ControlCenters);
                }
                if (context.CompanyService.Count() == 0)
                {
                    context.CompanyService.AddRange(CompanyServices);
                }
                context.SaveChanges();
            }
        }

        private static ControlCenter[] ControlCenters = {

        new ControlCenter() {ControlcenterKey="EW0p2PLcxhAzpq3j",mainsliderimage="bg1.jpg",mainsliderimage2="bg2.jpg",mainsliderimage3="bg3.jpg",mainsliderimage4="bg4.jpg",Adress="Cumhuriyet Mahallesi Gazi Caddesi Tunç Sokak Uslukent Sitesi B Blok 8A 16140 Nilüfer/BURSA",Phone="+(90) 224 253 4966",Email="bilgi@3escomputer.com",webadress="https://www.3escomputer.com",Logo="logo.png",socialnetwork1="https://www.instagram.com/rhymeerr",socialnetwork2="https://www.instagram.com",socialnetwork3="https://www.facebook.com/groups/34316341747/",socialnetwork4="https://www.youtube.com",parallax1="parallax1.jpg",parallax2="parallax2.jpg",parallax3="parallax3.jpg"}
        };
        private static CompanyService[] CompanyServices = {

        new CompanyService() {ControlCenter = ControlCenters[0],name="WEB TASARIM & YAZILIM",longexplanation="",shortexplanation="Web tasarım firmaları deyince akla gelen 3ES Bilgisayar ile, yeni ve modern bir web siteniz olsun! Google'da üst sıralarda gözükün!",icon="fa fa-desktop",image="webdesing1.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="BILGISAYAR SATIŞ & DESTEK",longexplanation="Uzun",shortexplanation="Sizin için en uygun bilgisayarı en kısa sürede ve size en uygun fiyata elde etmek için iletişime geçin!",icon="fa fa-laptop",image="computersales.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="TEKNIK SERVIS",longexplanation="Uzun",shortexplanation="Yerinde servis hizmetimiz sayesinde şirket veya kurumunuzun sorunlarını daha hızlı ve güvenli bir şekilde sonuca ulaştırıyoruz.",icon="fa fa-lightbulb-o",image="Technical-Support.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="NOTEBOOK TAMIRI",longexplanation="Uzun",shortexplanation="Bütün marka ve model Laptop & Dizüstü bilgisayarlarınızın Donanımsal veya Yazılımsal tamiri",icon="fa fa-codepen",image="notebookrepair.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="DANIŞMANLIK",longexplanation="Uzun",shortexplanation="Teknolojik ürünleri en yararlı şekilde faydalanması ve durumuna göre belirlediğimiz hizmetleri profesyonel bir şekilde gerçekleştiriyoruz.",icon="fa fa-bar-chart",image="danşmanlık.png"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="ÜRÜN SATIŞ & DESTEK",longexplanation="Uzun",shortexplanation="Ürün satış, destek, güncelleme, değişim ve aklınıza gelebicek bütün hizmetlerle ilgili destek alın!",icon="fa fa-dollar",image="aftersales.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="BAKIM ANLAŞMALI DESTEK",longexplanation="Uzun",shortexplanation="Kurumsal bakım anlaşmalı ve düzenli bakım desteği.",icon="fa fa-comments",image="bakımd.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="Sunucu Barındırma & Kiralama",longexplanation="Uzun",shortexplanation="Network yapınızı yakından yönetmek için sunucu barındırma ve kiralama hizmeti.",icon="fa fa-server",image="sunucu.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="CCTV HIZMETLERIMIZ",longexplanation="Uzun",shortexplanation="Bütün iç ve Dış ortam muhafaza ve güvenlik izleme sistemleri için hemen ulaşın.",icon="fa fa-camera",image="cctv.jpeg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="YAPISAL KABLOLAMA & AĞ KURULUMU",longexplanation="Uzun",shortexplanation="Fiber ve UTP Kablolama ve Ağ kurulumu hizmetleri sağlamaktayız.",icon="fa fa-database",image="yapisal-kablolama.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="GÜVENLIK TESTLERI",longexplanation="Uzun",shortexplanation="Olası bir saldırıya karşı Penetrasyon testleri ve bu testler sonucunda açıkların kapatılmasını sağlamaktayız.",icon="fa fa-shield",image="PenetrationTesting-1.jpg"},
        new CompanyService() {ControlCenter = ControlCenters[0],name="VERI KURTARMA",longexplanation="Uzun",shortexplanation="CD/DVD,USB, Diskler,DLT,DAT,LTO optik cihazlar,harici sürücüler vb.. Cihazlardan veri kurtarılması",icon="fa fa-table",image="bigstock-Backup-Storage-Data-Internet-T-287005189-1024x565.jpg"},
        };
    }
}
