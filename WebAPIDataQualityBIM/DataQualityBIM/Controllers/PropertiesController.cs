using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataQualityBIM.Models;

namespace DataQualityBIM.Controllers
{
    public class PropertiesController : ApiController
    {
        List<IFCProperties> Properties = new List<IFCProperties>();

          public PropertiesController()
        {
            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Wall", IfcType = "IFCWall", Breite = "a", Id = 1 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Beam", IfcType = "IFCBeam", Breite = "b", Id = 2 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Wall", IfcType = "", Breite = "abc", Id = 3 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "coloumn", IfcType = "IFCColoumn", Breite = "c", Id = 4 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Beam", IfcType = "IFCBeam", Breite = "d", Id = 5 });

            Properties.Add(new IFCProperties { ContentType = "", Tag = "Wall", IfcType = "", Breite = "e", Id = 6});

            Properties.Add(new IFCProperties { ContentType = "", Tag = "Wall", IfcType = "IFCWall", Breite = "r", Id = 7 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Wall", IfcType = "IFCWall", Breite = "p", Id = 0 });

            Properties.Add(new IFCProperties { ContentType = "", Tag = "Wall", IfcType = "", Breite = "", Id = 8 });

            Properties.Add(new IFCProperties { ContentType = "", Tag = "Beam", IfcType = "", Breite = "", Id = 10 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Beam", IfcType = "IFCBeam", Breite = "d", Id = 12 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Beam", IfcType = "", Breite = "d", Id = 11 });

            Properties.Add(new IFCProperties { ContentType = "", Tag = "Beam", IfcType = "IFCBeam", Breite = "d", Id = 13 });

            Properties.Add(new IFCProperties { ContentType = "IFCObject", Tag = "Beam", IfcType = "IFCBeam", Breite = "", Id = 9 });
        }


        
        
        // GET: api/Properties

        public List<IFCProperties> Get()
        {
            return Properties;
        }
                        
        // GET: api/Properties/AllinCompletData
        [Route("api/Properties/AllinCompletedata")]
        [HttpGet]
        public IHttpActionResult AllinCompleteData()
        {
            var IFCtypeproperties = Properties.Where(s => s.Tag == "" || s.IfcType == "" || s.ContentType == "" || s.Id == 0 || s.Breite == "");

            if (Properties == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Ifcobject not found");
            }
            return Ok(IFCtypeproperties);
        }
        // GET: api/Properties/AllCompletData
        [Route("api/Properties/AllCompletedata")]
        [HttpGet]
        public IHttpActionResult AllCompleteData()
        {
            var IFCtypeproperties = Properties.Where(s => s.Tag != "" ).Where(s=> s.IfcType != "" ).Where(s=>s.ContentType != "" ).Where(s=> s.Id != 0 ).Where(s=> s.Breite != "");

            if (Properties == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Ifcobject not found");
            }
            return Ok(IFCtypeproperties);
        }


        // GET: api/Properties/getallproperties/tag
        public IHttpActionResult Get(string tag )
        {
            var IFCtypeproperties = Properties.Where(s => s.Tag== tag  );
           
             if (Properties == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Ifcobject not found");
            }
            return Ok(IFCtypeproperties);
        }

        // GET: api/Properties/getallproperties/completedata/tag
        [Route ("api/Properties/completedata/{tag}")]
        [HttpGet]
        public IHttpActionResult completedata(string tag)
        {
            var IFCtypeproperties = Properties.Where(s => s.Tag == tag && s.IfcType != string.Empty && s.ContentType != string.Empty && s.Id != 0 && s.Breite != string.Empty);
                
            if (Properties == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Ifcobject not found");
            }
            return Ok(IFCtypeproperties);
        }

        // GET: api/Properties/getallproperties/incompletedata/tag
        [Route("api/Properties/incompletedata/{tag}")]
        [HttpGet]
        public IHttpActionResult incompletedata(string tag)
        {
            var IFCtypeproperties = Properties.Where(s => s.Tag == tag)
                .Where(s => s.ContentType == string.Empty || s.Breite == string.Empty || s.IfcType == string.Empty );


            if (Properties == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Ifcobject not found");
            }
            return Ok(IFCtypeproperties);
        }

       


    }
}
