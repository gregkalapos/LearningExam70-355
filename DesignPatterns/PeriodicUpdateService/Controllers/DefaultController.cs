using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace PeriodicUpdateService.Controllers
{
    public class DefaultController : ApiController
    {       
        public HttpResponseMessage GetNewTile()
        {

           // Content = new StringContent(XML, Encoding.UTF8, "application/xml")
            var response = Request.CreateResponse(HttpStatusCode.OK, Generator.Generate().GetContent(), "application/xml");
       //     response.Headers.Add("X-WNS-Expires", tilesSubtitle.AddMinutes(15).ToString("r"));
       //     response.Headers.Add("X-WNS-Tag", position.ToString());

            return response;
        }

        class Generator
        {
            public static TileContent Generate()
            {
                Random rnd = new Random(DateTime.Now.Second);

                TileContent content = new TileContent()
                {
                    Visual = new TileVisual()
                    {
                        Branding = TileBranding.NameAndLogo,

                        TileSmall = new TileBinding()
                        {
                            Content = new TileBindingContentAdaptive()
                            {
                                Children =
                {
                    new TileText() { Text = "PeriodicSmall" + rnd.Next(30) }

                }

                            }
                        },

                        TileMedium = new TileBinding()
                        {
                            Content = new TileBindingContentAdaptive()
                            {
                                Children =
                {
                    new TileText() { Text = "PeriodicMedium" + rnd.Next(30) }
                }
                            }
                        },

                        TileWide = new TileBinding()
                        {
                            Content = new TileBindingContentAdaptive()
                            {
                                Children =
                {
                    new TileText() { Text = "PeriodicWide" + rnd.Next(30) }
                }
                            }
                        },

                        TileLarge = new TileBinding()
                        {
                            Content = new TileBindingContentAdaptive()
                            {
                                Children =
                {
                    new TileText() { Text = "PeriodicLarge" + rnd.Next(30) }
                }
                            }
                        }
                    }
                };

                return content;
            }
        }
    }
}
