using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace YPlateVision
{
    /// <summary>
    /// Класс для сообщений формата json, отпрвляемых в ответ на запрос
    /// </summary>
    public class JMessage
    {
        /// <summary>
        /// Вспомогательный класс для хранения одного номера
        /// </summary>
        public class JMNumber
        {
            public string nomer;
        }

        /// <summary>
        /// Массив номеров, найденных и распознанных на картинке
        /// </summary>
        public JMNumber[] nomers;

        /// <summary>
        /// Результат распознавания
        /// </summary>
        public string result;

        public JMessage()
        {
            nomers = new JMNumber[0];
            result = "ERR";
        }

        public JMessage(string number)
        {
            nomers = new JMNumber[1];
            nomers[0] = new JMNumber();
            nomers[0].nomer = number;
            result = "OK";
        }

        public byte[] ToBytes()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(this, Formatting.Indented));
        }

        public override string ToString()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            return json;
        }
    }
}
