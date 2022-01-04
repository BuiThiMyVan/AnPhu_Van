using idn.AnPhu.Biz.Persistance.SqlServer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class ServiceFactory
    {
        static Hashtable services = new Hashtable();

        static ServiceFactory()
        {
            #region["Auth"]
            services.Add(typeof(Sys_UserManager), new Sys_UserManager(new Sys_UserProvider()));
            services.Add(typeof(Sys_GroupManager), new Sys_GroupManager(new Sys_GroupProvider()));
            services.Add(typeof(NewsCategoriesManager), new NewsCategoriesManager(new NewsCategoriesProvider()));
            services.Add(typeof(NewsManager), new NewsManager(new NewsProvider()));
            services.Add(typeof(PrdCategoriesManager), new PrdCategoriesManager(new PrdCategoriesProvider()));
            services.Add(typeof(ProductManager), new ProductManager(new ProductProvider()));
            services.Add(typeof(ProductReviewsManager), new ProductReviewsManager(new ProductReviewsProvider()));
            services.Add(typeof(ProductVersionsManager), new ProductVersionsManager(new ProductVersionsProvider()));
            services.Add(typeof(ProductPropertiesManager), new ProductPropertiesManager(new ProductPropertiesProvider()));
            services.Add(typeof(UsersManager), new UsersManager(new UsersProvider()));
            services.Add(typeof(HtmlPageCategoriesManager), new HtmlPageCategoriesManager(new HtmlPageCategoriesProvider()));
            services.Add(typeof(HtmlPagesManager), new HtmlPagesManager(new HtmlPagesProvider()));
            services.Add(typeof(AdBannerRightsManager), new AdBannerRightsManager(new AdBannerRightsProvider()));
            services.Add(typeof(AdBannerLeftsManager), new AdBannerLeftsManager(new AdBannerLeftsProvider()));
            services.Add(typeof(NewBannerRightsManager), new NewBannerRightsManager(new NewBannerRightsProvider()));
            services.Add(typeof(NewBannerLeftsManager), new NewBannerLeftsManager(new NewBannerLeftsProvider()));
            services.Add(typeof(CompanyManager), new CompanyManager(new CompanyProvider()));
            services.Add(typeof(PopupAdvertisementManager), new PopupAdvertisementManager(new PopupAdvertisementProvider()));
            services.Add(typeof(VideoCategoriesManager), new VideoCategoriesManager(new VideoCategoriesProvider()));
            services.Add(typeof(VideosManager), new VideosManager(new VideosProvider()));
            services.Add(typeof(SlideBannersManager), new SlideBannersManager(new SlideBannersProvider()));
            services.Add(typeof(PriceOptionsManager), new PriceOptionsManager(new PriceOptionsProvider()));
            services.Add(typeof(LocationDiscountsManager), new LocationDiscountsManager(new LocationDiscountsProvider()));
            services.Add(typeof(ImageFootersManager), new ImageFootersManager(new ImageFootersProvider()));
            #endregion
        }

        public static T GetService<T>()
        {
            foreach (var service in services.Values)
            {
                if (service is T)
                {
                    return (T)service;
                }
            }
            return default(T);
        }

        public static Sys_UserManager Sys_UserManager
        {
            get
            {
                return (Sys_UserManager)services[typeof(Sys_UserManager)];
            }
            set
            {
                services[typeof(Sys_UserManager)] = value;
            }
        }
        public static Sys_GroupManager Sys_GroupManager
        {
            get
            {
                return (Sys_GroupManager)services[typeof(Sys_GroupManager)];
            }
            set
            {
                services[typeof(Sys_GroupManager)] = value;
            }
        }

        public static NewsCategoriesManager NewsCategoriesManager
        {
            get
            {
                return (NewsCategoriesManager)services[typeof(NewsCategoriesManager)];
            }
            set
            {
                services[typeof(NewsCategoriesManager)] = value;
            }
        }

        public static NewsManager NewsManager
        {
            get
            {
                return (NewsManager)services[typeof(NewsManager)];
            }
            set
            {
                services[typeof(NewsManager)] = value;
            }
        }

        public static PrdCategoriesManager PrdCategoriesManager
        {
            get
            {
                return (PrdCategoriesManager)services[typeof(PrdCategoriesManager)];
            }
            set
            {
                services[typeof(PrdCategoriesManager)] = value;
            }
        }

        public static ProductManager ProductManager
        {
            get
            {
                return (ProductManager)services[typeof(ProductManager)];
            }
            set
            {
                services[typeof(ProductManager)] = value;
            }
        }
        public static ProductReviewsManager ProductReviewsManager
        {
            get
            {
                return (ProductReviewsManager)services[typeof(ProductReviewsManager)];
            }
            set
            {
                services[typeof(ProductReviewsManager)] = value;
            }
        }
        public static ProductVersionsManager ProductVersionsManager
        {
            get
            {
                return (ProductVersionsManager)services[typeof(ProductVersionsManager)];
            }
            set
            {
                services[typeof(ProductVersionsManager)] = value;
            }
        }

        public static ProductPropertiesManager ProductPropertiesManager
        {
            get
            {
                return (ProductPropertiesManager)services[typeof(ProductPropertiesManager)];
            }
            set
            {
                services[typeof(ProductPropertiesManager)] = value;
            }
        }

        public static UsersManager UsersManager
        {
            get
            {
                return (UsersManager)services[typeof(UsersManager)];
            }
            set
            {
                services[typeof(UsersManager)] = value;
            }
        }

        public static HtmlPageCategoriesManager HtmlPageCategoriesManager
        {
            get
            {
                return (HtmlPageCategoriesManager)services[typeof(HtmlPageCategoriesManager)];
            }
            set
            {
                services[typeof(HtmlPageCategoriesManager)] = value;
            }
        }

        public static AdBannerRightsManager AdBannerRightsManager
        {
            get
            {
                return (AdBannerRightsManager)services[typeof(AdBannerRightsManager)];
            }
            set
            {
                services[typeof(AdBannerRightsManager)] = value;
            }
        }

        public static AdBannerLeftsManager AdBannerLeftsManager
        {
            get
            {
                return (AdBannerLeftsManager)services[typeof(AdBannerLeftsManager)];
            }
            set
            {
                services[typeof(AdBannerLeftsManager)] = value;
            }
        }

        public static NewBannerLeftsManager NewBannerLeftsManager
        {
            get
            {
                return (NewBannerLeftsManager)services[typeof(NewBannerLeftsManager)];
            }
            set
            {
                services[typeof(NewBannerLeftsManager)] = value;
            }
        }

        public static NewBannerRightsManager NewBannerRightsManager
        {
            get
            {
                return (NewBannerRightsManager)services[typeof(NewBannerRightsManager)];
            }
            set
            {
                services[typeof(NewBannerRightsManager)] = value;
            }
        }

        public static CompanyManager CompanyManager
        {
            get
            {
                return (CompanyManager)services[typeof(CompanyManager)];
            }
            set
            {
                services[typeof(CompanyManager)] = value;
            }
        }

        public static PopupAdvertisementManager PopupAdvertisementManager
        {
            get
            {
                return (PopupAdvertisementManager)services[typeof(PopupAdvertisementManager)];
            }
            set
            {
                services[typeof(PopupAdvertisementManager)] = value;
            }
        }

        public static SlideBannersManager SlideBannersManager
        {
            get
            {
                return (SlideBannersManager)services[typeof(SlideBannersManager)];
            }
            set
            {
                services[typeof(SlideBannersManager)] = value;
            }
        }

        public static ImageFootersManager ImageFootersManager
        {
            get
            {
                return (ImageFootersManager)services[typeof(ImageFootersManager)];
            }
            set
            {
                services[typeof(ImageFootersManager)] = value;
            }
        }

        public static VideosManager VideosManager
        {
            get
            {
                return (VideosManager)services[typeof(VideosManager)];
            }
            set
            {
                services[typeof(VideosManager)] = value;
            }
        }

        public static VideoCategoriesManager VideoCategoriesManager
        {
            get
            {
                return (VideoCategoriesManager)services[typeof(VideoCategoriesManager)];
            }
            set
            {
                services[typeof(VideoCategoriesManager)] = value;
            }
        }

        public static LocationDiscountsManager LocationDiscountsManager
        {
            get
            {
                return (LocationDiscountsManager)services[typeof(LocationDiscountsManager)];
            }
            set
            {
                services[typeof(LocationDiscountsManager)] = value;
            }
        }

        public static PriceOptionsManager PriceOptionsManager
        {
            get
            {
                return (PriceOptionsManager)services[typeof(PriceOptionsManager)];
            }
            set
            {
                services[typeof(PriceOptionsManager)] = value;
            }
        }

        public static HtmlPagesManager HtmlPagesManager
        {
            get
            {
                return (HtmlPagesManager)services[typeof(HtmlPagesManager)];
            }
            set
            {
                services[typeof(HtmlPagesManager)] = value;
            }
        }
    }
}
