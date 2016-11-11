using hhnextWeb.Data;
using hhnextWeb.Data.Entities;
using hhnextWeb.Filters;
using hhnextWeb.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace hhnextWeb.Controllers
{
    [RoutePrefix("api/Ports")]
    [BasicAuthorizeAttribute]
    public class DevicePortsController : BaseApiController
    {
        public DevicePortsController(IRepository repo)
            : base(repo)
        {
        }


        /*
        //GET: api/DevicePorts
        [Route("")]
        [HttpPost]
        public IEnumerable<DevicePortsReturnModel> GetAllPortsByDevice(DevicePortBindingModel model)
        {

            Device device = TheRepository.GetDeviceByMac(model.mac);
            if (device == null)
                return Enumerable.Empty<DevicePortsReturnModel>();

            string userName = User.Identity.Name;
            if (!TheRepository.CheckDeviceUser(device.Id, userName))
                return new DevicePortsReturnModel[] { };

            var query = TheRepository.GetAllDevicePorts(device.Id).ToList().Select(s => TheModelFactory.Create(s));
            return query;
        }

        // GET: api/DevicePorts/5
        //public string Get(int entityId,int id)
        //{
        //    return "value";
        //}

        [Route("create")]
        [HttpPost]
        public IHttpActionResult Add(DevicePortBindingModel devicePortsModels)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Device device = TheRepository.GetDeviceByMac(devicePortsModels.mac);
            if (null == device)
                return BadRequest(ModelState);

            string userName = User.Identity.Name;
            if (!TheRepository.CheckDeviceUser(device.Id, userName))
                return BadRequest();


            while (TheRepository.IsExistsDevicePort(device.Id, devicePortsModels.PortNo))
                TheRepository.DeleteDevicePort(device.Id, devicePortsModels.PortNo);

            DevicePort bp = new DevicePort()
            {
                DeviceId = device.Id,
                Port = devicePortsModels.PortNo,
                PortDescriptionId = devicePortsModels.PortTypeId,
                Alias = devicePortsModels.PortName
            };

            if (!TheRepository.Insert(bp))
                return BadRequest(ModelState);

            return Ok();

        }

        [Route("remove")]
        [HttpPost]
        public IHttpActionResult Remove(DevicePortBindingModel devicePortsModels)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            Device device = TheRepository.GetDeviceByMac(devicePortsModels.mac);
            if (null == device)
                return BadRequest(ModelState);

            string userName = User.Identity.Name;
            if (!TheRepository.CheckDeviceUser(device.Id, userName))
                return BadRequest();

            TheRepository.DeleteDevicePort(device.Id, devicePortsModels.PortNo);

            return Ok();

        }

        // PUT: api/DevicePorts/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/DevicePorts/5
        //public void Delete(int id)
        //{
        //}
        */
    }
}