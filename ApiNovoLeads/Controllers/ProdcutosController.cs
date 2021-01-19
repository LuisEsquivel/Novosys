using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiNovosys;
using ApiNovosys.Dto.Productos;
using ApiPlafonesWeb.Helpers;
using ApiPlafonesWeb.Interface;
using ApiPlafonesWeb.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNovosys.Controllers
{

    /// <summary>
    /// Productos Controller
    /// </summary>
    [Route("api/productos/")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiProductos")]
    public class ComoSeEnteroController : ControllerBase
    {
 
            private IGenericRepository<Producto> repository;
            private IMapper mapper;
            private Response response;

 
            public ComoSeEnteroController(ApplicationDbContext context, IMapper _mapper)
            {
                this.mapper = _mapper;
                this.repository = new GenericRepository<Producto>(context);
                this.response = new Response();
            }


            /// <summary>
            ///Productos Get
            /// </summary>
            /// <returns>lista de productos</returns>
            [HttpGet("get")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public IActionResult Get()
            {

                var list = repository.GetAll();

                var listDto = new List<ProductoDTO>();

                foreach (var row in list)
                {
                    listDto.Add(mapper.Map<ProductoDTO>(row));
                }

                return Ok(response.ResponseValues(this.Response.StatusCode, listDto));

            }



            /// <summary>
            /// Obtener producto por el Id
            /// </summary>
            /// <param name="Id"></param>
            /// <returns>StatusCode 200</returns>
            [HttpGet("GetById/{Id:int}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            public IActionResult GetById(int Id)
            {
                return Ok(this.response.ResponseValues(this.Response.StatusCode, mapper.Map<ProductoDTO>(repository.GetById(Id))));
            }





            /// <summary>
            /// Agregar un nuevo producto
            /// </summary>
            /// <param name="dto"></param>
            /// <returns>StatusCode 200</returns>
            [HttpPost("Add")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public IActionResult Add([FromBody] ProductoDTO dto)
            {
                if (dto == null)
                {
                    return BadRequest(StatusCodes.Status406NotAcceptable);
                }


                if (repository.Exist(x => x.NombreVar == dto.NombreVar))
                {
                    return BadRequest(this.response.ResponseValues(StatusCodes.Status406NotAcceptable, null, "El registro Ya Existe!!"));
                }

                var producto = mapper.Map<Producto>(dto);

                if (!repository.Add(producto))
                {
                    return BadRequest(this.response.ResponseValues(StatusCodes.Status500InternalServerError, null, $"Algo salió mal guardar el registro: {dto.NombreVar}"));
                }

                return Ok(
                             response.ResponseValues(this.Response.StatusCode,
                                                     mapper.Map<ProductoDTO>(repository.GetById(producto.CveProductoInt))
                                                   )
                          );
            }



            /// <summary>
            /// Actualizar producto
            /// </summary>
            /// <param name="dto"></param>
            /// <returns>StatusCode 200</returns>
            [HttpPut("Update")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public IActionResult Update([FromBody] ProductoDTO dto)
            {
                if (dto == null)
                {
                    return BadRequest(StatusCodes.Status406NotAcceptable);
                }

                if (repository.Exist(x => x.NombreVar == dto.NombreVar && x.CveProductoInt != dto.CveProductoInt))
                {
                    return BadRequest(this.response.ResponseValues(StatusCodes.Status406NotAcceptable, null, "El Registro Ya Existe!!"));
                }

                var producto = mapper.Map<Producto>(dto);
                var update = repository.GetByValues(x => x.CveProductoInt == dto.CveProductoInt).FirstOrDefault();

                if (!repository.Update(producto, producto.CveProductoInt))
                {
                    return BadRequest(this.response.ResponseValues(StatusCodes.Status500InternalServerError, null, $"Algo salió mal al actualizar el registro: {dto.NombreVar}"));
                }


                return Ok(
                           response.ResponseValues(this.Response.StatusCode,
                                                   mapper.Map<ProductoDTO>(repository.GetById(producto))
                                                 )
                        );

            }



            /// <summary>
            /// Eliminar producto por Id
            /// </summary>
            /// <param name="Id"></param>
            /// <returns>StatusCode 200</returns>
            [HttpDelete("Delete/{Id:int}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public IActionResult Delete(int Id)
            {
                if (Id <= 0)
                {
                    return BadRequest(this.response.ResponseValues(StatusCodes.Status406NotAcceptable, null, $"El parámetro (Id) es obligatorio"));
                }


                if (repository.Exist(x => x.CveProductoInt  == Id))
                {
                    return BadRequest(this.response.ResponseValues(StatusCodes.Status406NotAcceptable, null, $"El registro con Id: {Id} No existe"));
                }

                var row = repository.GetById(Id);

                var comoseentero = mapper.Map<Producto>(row);

                if (!repository.Delete(comoseentero))
                {
                    return BadRequest(this.response.ResponseValues(StatusCodes.Status500InternalServerError, null, $"Algo salió mal al eliminar el registro: {comoseentero.NombreVar}"));

                }


                return Ok(response.ResponseValues(this.Response.StatusCode));
            }

        }


    }

