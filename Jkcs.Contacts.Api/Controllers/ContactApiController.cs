using Jkcs.Contacts.Data.Contracts;
using Jkcs.Contacts.Domain.Contracts.Interfaces;
using Jkcs.Contacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Jkcs.Contacts.Api.Controllers
{
    public class ContactApiController : ApiController
    {
        private readonly IUnitOfWork _dataRepositoryFactory;
        private readonly IContactService _contactService;

        public ContactApiController(IUnitOfWork unitOfWork, IContactService contactService)
        {
            _dataRepositoryFactory = unitOfWork;
            _contactService = contactService;
        }

        //[Authorize]
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                ICollection<Contact> _contacts = await _contactService.GetAllContacts(_dataRepositoryFactory);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _contacts);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;

                //_logger.Error(ex);
                //return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        public async Task<HttpResponseMessage> Get(int contactId)
        {
            try
            {
                Contact _contact = await _contactService.GetContactByContactId(contactId, _dataRepositoryFactory);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _contact);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;

                //_logger.Error(ex);
                //return this.GenarateInternalServerError(Resources.SystemMessages.ErrorLoggedInUserNull);
            }
        }

        public async Task<HttpResponseMessage> Post(Contact contact)
        {
            try
            {
                Contact _createdContact = await _contactService.CreateContact(contact, _dataRepositoryFactory);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, _createdContact);

                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        public async Task<HttpResponseMessage> Put(Contact contact)
        {
            try
            {
                Contact _updatedContact = await _contactService.UpdateContact(contact, _dataRepositoryFactory);
                HttpResponseMessage responce = Request.CreateResponse(HttpStatusCode.OK, _updatedContact);

                return responce;
            }
            catch (Exception)
            {
                HttpResponseMessage responce = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return responce;
            }
        }

        public async Task<HttpResponseMessage> Delete(int contactId)
        {
            try
            {
                await _contactService.DeleteContact(contactId, _dataRepositoryFactory);
                HttpResponseMessage responce = Request.CreateResponse(HttpStatusCode.OK);

                return responce;
            }
            catch (Exception)
            {
                HttpResponseMessage responce = Request.CreateResponse(HttpStatusCode.InternalServerError);
                return responce;
            }
        }
    }
}
