using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ParcelManagementSystem.Data;
using ParcelManagementSystem.DTOs;
using ParcelManagementSystem.Migrations;
using ParcelManagementSystem.Models;
using Parcel = ParcelManagementSystem.Models.Parcel;


namespace ParcelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelController : ControllerBase

    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ParcelController(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/<ParcelController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParcelReadDTO>>> GetParcels()
        {
            var parcels = await _context.Parcels.ToListAsync();
            var parcelDTOs = _mapper.Map<List<ParcelReadDTO>>(parcels);
            return Ok(parcelDTOs);

        }

        // GET api/<ParcelController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelReadDTO>> GetParcel(int id)
        {
            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            }
            var parcelDTO = _mapper.Map<ParcelReadDTO>(parcel);
            return Ok(parcelDTO);
        }

        // POST api/<ParcelController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ParcelReadDTO>> PostParcel(ParcelCreateDTO parcelCreateDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var parcel = _mapper.Map<Parcel>(parcelCreateDTO);
            parcel.DateAccepted = DateTime.UtcNow;
            _context.Parcels.Add(parcel);
             await _context.SaveChangesAsync();
            var parcelDTO = _mapper.Map<ParcelReadDTO>(parcel);


            return CreatedAtAction(nameof(GetParcel), new { id = parcel.Id }, parcelDTO);


            }

        

    [HttpPut("{id}")]
    public async Task<ActionResult> EditParcel(int id, ParcelUpdateDTO parcelUpdateDTO)
    {

            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();

            }

            _mapper.Map (parcelUpdateDTO, parcel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParcelExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();

        }




    // DELETE api/<ParcelController>/5
    [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteParcel(int id)
        {
            var parcel = await _context.Parcels.FindAsync(id);
            if (parcel == null)
            {
                return NotFound();
            
            }
            _context.Parcels.Remove(parcel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool ParcelExists(int id)
        {
            return _context.Parcels.Any(e => e.Id == id);
        }
    } }
