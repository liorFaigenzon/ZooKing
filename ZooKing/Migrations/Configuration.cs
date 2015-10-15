namespace ZooKing.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZooKing.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZooKing.DAL.ZooKingContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZooKing.DAL.ZooKingContext context)
        {
            //-------------------------------------------------------
            if (!context.Roles.Any(r => r.Name == "Admins"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admins" };

                manager.Create(role);
            }
            //-------------------------------------------------------
            if (!context.Users.Any(u => u.UserName == "admin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "Admins");
            }
            //-------------------------------------------------------

            List<Animal> Animal = new List<Animal>
            {
                new Animal{Name = "horse sea",
                           Age=15},
                new Animal{Name = "sea horse",
                           Age=15
                           }
            };


            List<Area> Area1 = new List<Area>
            {
                new Area{Size = 10,
                         Name="kkk",
                         Animals= Animal},
                new Area{Size = 10,
                         Name="yyyy",
                         Animals= Animal},
            };


            List<Area> Area2 = new List<Area>
            {
                new Area{Size = 10,
                         Name="fff",
                         Animals= null},
                new Area{Size = 10,
                         Name="ppp",
                         Animals= null},
            };

            context.Zoos.AddOrUpdate(
              p => p.ID,
              new Zoo { Name = "Peter sea world",
                        Addres = "אטלנטה",
                        ShortInfo = "come and enjoy1",
                        YearOfEstablishment = DateTime.Parse("2005-09-01"), 
                        Areas = Area1},
              new Zoo { Name = "YODA the caT jungle",
                        Addres= "אפריקה",
                        ShortInfo ="come and enjoy2",
                        YearOfEstablishment=DateTime.Parse("2005-09-01"),
                        Areas=Area2}
            );
            
        }
    }
}
//<div id="map" style="height: 400px; width: 550px;vertical-align:central;"></div>
//<script>

//    function initMap() {
//        var map = new google.maps.Map(document.getElementById('map'), {
//            zoom: 8,
//            center: { lat: 31.466114  , lng: 34.484749 }
//        });
//        var geocoder = new google.maps.Geocoder();
//        geocodeAddress(geocoder, map);
//    }

//    function geocodeAddress(geocoder, resultsMap) {
//        var address = '@Html.DisplayFor(model => model.Addres)';
//        geocoder.geocode({ 'address': address }, function (results, status) {
//            if (status === google.maps.GeocoderStatus.OK) {
//                resultsMap.setCenter(results[0].geometry.location);
//                var marker = new google.maps.Marker({
//                    map: resultsMap,
//                    position: results[0].geometry.location
//                });
//            } else {
//                alert('לא נמצא הכתובת: ' + status);
//            }
//        });
//    }

//</script>
//<script async defer
//        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCQ5IULUiy8lwGACkjvCYYuF1HCUOFBACw&signed_in=true&callback=initMap"></script>