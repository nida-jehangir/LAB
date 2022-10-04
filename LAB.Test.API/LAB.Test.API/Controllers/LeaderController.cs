using LAB.Test.API.Models;
using LAB.Test.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LAB.Test.API.Controllers
{
    [Route("leader")]
    [ApiController]
    public class LeaderController : ControllerBase
    {
        private ILeaderService _leaderService;
        public LeaderController(ILeaderService leaderService)
        {
            _leaderService = leaderService;
        }

        [HttpPost]
        [Route("FindLeaderValue")]
         public async Task<IActionResult> FindLeaderValue([FromForm]LeaderModel leaderModel)
         {
             if(leaderModel == null)
             {
                 return BadRequest();
             }
             if(leaderModel.File == null)
             {
                 return BadRequest("No file is uploaded");
             }
             if(!leaderModel.File.FileName.ToLower().EndsWith(".csv"))
             {
                 return BadRequest("Uploaded file must be of type csv");
             }
             else
             {
                 using (StreamReader streamReader = new StreamReader(leaderModel.File.OpenReadStream()))
                 {
                     var fileContent = await streamReader.ReadToEndAsync();

                    if(String.IsNullOrEmpty(fileContent))
                    {
                        return BadRequest("Uploaded file is empty");
                    }

                     var values = fileContent.Split(',');
                    
                     try
                     {
                         int[] intValues = Array.ConvertAll(values, int.Parse);
                         return Ok(_leaderService.FindLeaderOfValues(intValues));
                     }
                     catch(FormatException)
                     {
                         return BadRequest("csv file should only contain integers");
                     }                    
                 }
             }
         } 

       
    }
}
