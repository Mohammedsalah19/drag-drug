using AccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
namespace WepApi.Controllers
{
    public class DrugController : ApiController
    {
        //  [HttpGet] // custom get method

        //public IEnumerable<drug> Get()
        //{

        //    using (MedicalDrugDBEntities dbs = new MedicalDrugDBEntities())
        //    {

        //        return dbs.drugs.Where(s => s.id == 2).ToList();

        //    }
        //}

         [HttpGet] // custom name method
        // GET: api/Drug
        public HttpResponseMessage loadalldrugs(string type="All")
        {
            using (MedicalDrugDBEntities dbs = new MedicalDrugDBEntities())
            {

                switch (type)
                {
                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, dbs.drugs.ToList());
                    case "Egypt":
                        return Request.CreateResponse(HttpStatusCode.OK, dbs.drugs.Where(s => s.Company_name.Contains(type)).ToList());
                    case "Eva ":
                        return Request.CreateResponse(HttpStatusCode.OK, dbs.drugs.Where(s => s.Company_name.Contains(type)).ToList());
                    default:
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "this type is invaild");
                }
                 
            }
        }
        [HttpGet]// custom name method
        // GET: api/Drug/5
        public HttpResponseMessage loadDragsByID(int id)
        {

            using (MedicalDrugDBEntities dbs = new MedicalDrugDBEntities())
            {
 

                var entity = dbs.drugs.FirstOrDefault(s => s.id == id);


                if (entity== null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,"There is no Drug with this id" + id);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);

                }
            }
        }
        // POST: api/Drug
        public HttpResponseMessage Put([FromBody]drug drug, int id)
        {
            try
            {



                using (MedicalDrugDBEntities dbs = new MedicalDrugDBEntities())
                {

                    var entity = dbs.drugs.FirstOrDefault(s => s.id == id);

                    if (entity == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                    else
                    {
                        entity.Company_name = drug.Company_name;
                        entity.New_Price = drug.New_Price;
                        entity.No_of_Units = drug.No_of_Units;
                        entity.Trade_Name = drug.Trade_Name;
                        dbs.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);

                    }
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
         
        // PUT: api/Drug/5
        public HttpResponseMessage Post (int id, [FromBody]drug value)
        {
            try
            {
                using (MedicalDrugDBEntities dbs = new MedicalDrugDBEntities()) {

                    dbs.drugs.Add(value);
                    dbs.SaveChanges();
                 return   Request.CreateResponse(HttpStatusCode.Created, value);


                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }

        }

        // DELETE: api/Drug/5
        public HttpResponseMessage Delete(int id)
        {
            using (MedicalDrugDBEntities dbs = new MedicalDrugDBEntities())
            {

                var entity = dbs.drugs.FirstOrDefault(s => s.id == id);

                if (entity != null )
                {
                    dbs.drugs.Remove(entity);
                    dbs.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Done the entity deleted");

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "th id is wrong");

                }

            }

 
        }
    }
}
