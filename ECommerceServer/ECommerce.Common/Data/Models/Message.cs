using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Common.Data.Models
{
    public class Message
    {
        public string serializedData;
        public Guid ID { get; set; }
        public Type Type { get; set; }

        public bool Published { get; set; }

        public Message(object data, Guid id)
        {
            this.Data = data;
            this.ID = id;
        }

        private Message()
        {

        }

        [NotMapped]
        public object Data
        {
            get => JsonConvert.DeserializeObject(this.serializedData, this.Type, 
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            set
            {
                this.Type = value.GetType();
                this.serializedData = JsonConvert.SerializeObject(value, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); 
            }
        }


    }
}
