#drgs-repository-MVCAPI


customapi by .net 

>> impelment main functions

1- GET
2- GET(id)
3-PUT
4-POST
5-DELETE
-----------------
Add class "RequiredHttpsAttribute"
    this class explain how use https rather than http
------------------------
WebApiConfig
implement

1-
      
            # this for remove json and preview xml only 
        

            config.Formatters.Remove(config.Formatters.XmlFormatter);
         #endregion
2-


            # region this for share api to differant projects which have different port


            //  this for jsonp
            //     var jsonpformatter = new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //  config.Formatters.Insert(0, jsonpformatter);


            // this for cors to deffirant origin
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            #endregion
            
3-
            # this for move from http tp https

              config.Filters.Add(new REquiredHttpsAttribute());

            
                        #endregion

