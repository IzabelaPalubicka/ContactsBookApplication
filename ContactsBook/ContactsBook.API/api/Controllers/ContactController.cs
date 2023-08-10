using ContactsBook.API.application.CreatingContact;
using ContactsBook.API.application.GettingContact;
using ContactsBook.API.application.UpdatingContact;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactsBook.API.api.Controllers
{
    /// <summary>
    /// Contact controller.
    /// </summary>
    [ApiController]
    [Route("contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateContact> _createValidator;
        private readonly IValidator<UpdateContact> _updateValidator;

        public ContactController(IMediator mediator, IValidator<CreateContact> createValidator, IValidator<UpdateContact> updateValidator)
        {
            _mediator = mediator;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> GetAllContacts([FromBody] GetContacts query)
        {
            var pagedList = await _mediator.Send(query);

            return Ok(pagedList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] CreateContact command)
        {
            await _createValidator.ValidateAndThrowAsync(command);

            await _mediator.Send(command);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact([FromBody] UpdateContact command)
        {
            await _updateValidator.ValidateAndThrowAsync(command);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}