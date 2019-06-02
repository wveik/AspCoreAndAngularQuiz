using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Helpers
{
	public static class SerializerDeserializerExtensions
	{
		public static byte[] Serializer(this object _object)
		{
			byte[] bytes;
			using (var memoryStream = new MemoryStream())
			{
				IFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(memoryStream, _object);
				bytes = memoryStream.ToArray();
			}
			return bytes;
		}

		public static T Deserializer<T>(this byte[] byteArray)
		{
			T returnValue;
			using (var memoryStream = new MemoryStream(byteArray))
			{
				IFormatter binaryFormatter = new BinaryFormatter();
				returnValue = (T)binaryFormatter.Deserialize(memoryStream);
			}
			return returnValue;
		}
	}
}