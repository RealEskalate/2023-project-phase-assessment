﻿using Application.Responses;
using Microsoft.AspNetCore.Mvc; 

namespace WebApi.Controllers
{
    public class ResponseHandler<T> 
    {
        public static IActionResult HandleResponse(BaseCommandResponse<T> response, int statusCode)
        {
            if (response.Success)
            {
                if (statusCode == 200)
                {
                    response.StatusCode = statusCode;
                    return new OkObjectResult(response);
                }
                else if (statusCode == 201)
                {   
                    response.StatusCode = statusCode;
                    return new CreatedResult("", response);
                }
                else if (statusCode == 204)
                {   
                    response.StatusCode = statusCode;
                    return new NoContentResult();
                }   
            }
            else
            {
                Console.WriteLine("Errorsssssssssssssssssssss");
                foreach (var error in response.Errors)
                {
                    Console.WriteLine(error);
                }
                if (response.StatusCode == StatusCodes.Status422UnprocessableEntity)
                {
                    return new UnprocessableEntityObjectResult(response);
                }
                else if (response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    return new BadRequestObjectResult(response);
                }
                else if (response.StatusCode == StatusCodes.Status404NotFound)
                {
                    return new NotFoundObjectResult(response);
                }
                else if (response.StatusCode == StatusCodes.Status500InternalServerError)
                {
                    return new ObjectResult(response)
                    {
                        StatusCode = StatusCodes.Status500InternalServerError,
                    };
                }
            }
            
            return new BadRequestObjectResult(response);
        }
    }
}
