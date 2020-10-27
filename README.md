This project covers the following content:  
![Project Content](https://github.com/sharship/ASP.Net-Core-3.1-MVC-REST-API/blob/master/External%20Resource/Content.PNG "Project Content")  
Fig. 1 The content of this project  

The architecture of this API is as below:  
![API Architecture](https://github.com/sharship/ASP.Net-Core-3.1-MVC-REST-API/blob/master/External%20Resource/Architecture.PNG "API Architecture")  
Fig. 2 API Architecture  

The HTTP End Points is as below:  
![API End Points](https://github.com/sharship/ASP.Net-Core-3.1-MVC-REST-API/blob/master/External%20Resource/API-End-Points.PNG "API End Points")  
Fig. 3 API End Points  


#### Dependency Injection & Register Services
The HTTP End Points is as below:  
![Service Lifetimes](https://github.com/sharship/ASP.Net-Core-3.1-MVC-REST-API/blob/master/External%20Resource/Service_Lifetimes.PNG "Service Lifetimes")  
Fig. 4 Service Lifetimes  

To register Repository **Interface into Services**, add service into **Startup.cs->ConfigureServices()** method as below:  
> public void ConfigureServices(IServiceCollection services)  
> {  
>      services.AddScoped<ICMTRepo, MockCMTRepo>();  
> }  

#### EF DB Migrations  
* **Connect DBContext with real DB**, via Connection String in appsettings.json (injected **Configuration** object in Startup class):  
> services.AddDbContext\<DBContext\>(  
>     opt => opt.UseSqlServer(  
>         Configuration.GetConnectionString("[Connection String Name]")  
>     )  
> );  


* Add migration:  
> dotnet ef migrations add \<MigrationName\>  

* Undo migration before update DB:  
> dotnet ef migrations remove  

* Update DB:  
> dotnet ef database update  

So far, two major blocks have been combined together as below:    
![Two major blocks](https://github.com/sharship/ASP.Net-Core-3.1-MVC-REST-API/blob/master/External%20Resource/Two_Major_Blocks.png "Two major blocks")  
Fig. 5 Two major blocks  

#### Connect DBContext with Repo
By connecting special Repository with DBContext, two major blocks (Controller-Repo & DBContext-Models-DB) are linked together. In this way, data can flow along the way as below:  

**real DB <--> DBContext (Reflecting Models) <--> Repository <--> Controller <--> API Client**  

Steps are as below:  
1. Create new Repo class (inherited from basic Repo Interface), and use Dependency Injection pattern to bring in an instanc of DBContext class.  
>    public class SqlCMTRepo : ICMTRepo  
>    {  
>        private readonly CMTContext _context;  
>   
>        public SqlCMTRepo(CMTContext context)  
>        {  
>             _context = context;  
>        }  
>    }  

2. Switch Repository Registeration in Startup.cs->ConfigureServices:  
> services.AddScoped\<ICMTRepo, SqlCMTRepo\>();

### Data Transfer Objects (DTO)
![Data Object Transfer (DTO)](https://github.com/sharship/ASP.Net-Core-3.1-MVC-REST-API/blob/master/External%20Resource/DTO.PNG "Data Object Transfer (DTO)")  
Fig. 6 Data Object Transfer (DTO)  

![Seperate DTO](https://github.com/sharship/ASP.Net-Core-3.1-MVC-REST-API/blob/master/External%20Resource/Seperate_DTOs.PNG "Seperate DTO")  
Fig. 7 Seperate DTO for different kinds of requests  

### CreatedAtRoute() vs. CreatedAtAction()


#### PUT Request
The line below connect new Dto (that is input) to old Model object from Repo:  
> _mapper.Map(\<new to-update Dto\>, \<old Model object from Repo\>);

#### PATCH Request
1. Update services in Startup.cs:  
> services.AddControllers().AddNewtonsoftJson();
2. Patch Action in Controller has special method signature:  
> [HttpPatch("{id}")]  
> public ActionResult UpdateCommandPartially(int id, **JsonPatchDocument**\<CommandUpdateDto\> patchDoc)  
3. Apply Patch Document to UpdateDto transferred from Model, and then map back *PatchDoc-Applied UpdateDto* to *initial Model from Repo*:   
> var cmdPatchDto = _mapper.Map<CommandUpdateDto>(cmdFromRepo);  
>   
> patchDoc.ApplyTo(cmdPatchDto, ModelState);  
> if (!TryValidateModel(cmdPatchDto))  
>     return ValidationProblem(ModelState);  
>   
> _mapper.Map(cmdPatchDto, cmdFromRepo);  



### Model Binding
