using HehKuerwle.ServerManagement.Commons.Monitoring.Packets;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace HehKuerwle.ServerManagement.Commons.Monitoring.Serialization
{
	public static class PacketSerialization
	{
		//static byte[] SerializeHeader(Type t)
		//{
		//	byte[] className = Encoding.UTF8.GetBytes(t.Name);
		//	byte[] result = new byte[className.Length + sizeof(int) + 1];
		//	result[0] = 0x00;
		//	Array.Copy(BitConverter.GetBytes(className.Length), 0, result, 1, sizeof(int));
		//	Array.Copy(className, 0, result, sizeof(int) + 1, className.Length);
		//	return result;
		//}

		//static byte[] SerializeProperty(PropertyInfo propertyInfo)
		//{
		//	byte[] className = Encoding.UTF8.GetBytes(t.Name);
		//	byte[] result = new byte[className.Length + sizeof(int) + 1];
		//	result[0] = 0x00;
		//	Array.Copy(BitConverter.GetBytes(className.Length), 0, result, 1, sizeof(int));
		//	Array.Copy(className, 0, result, sizeof(int) + 1, className.Length);
		//	return result;
		//}

		//public static byte[] Serialize(Object packet)
		//{
		//	List<byte> result = new List<byte>();
		//	Type packetType = packet.GetType();

		//	result.AddRange(SerializeHeader(packetType));
		//	PropertyInfo[] properties = packetType.GetProperties(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance));
		//	for(byte i = 0x01; i < properties.Length; ++i)
		//	{
				
		//		result.Add(i);
		//		SerializeProperty(properties[i - 1]);
		//	}
		//	return result.ToArray();
		//}

		public static byte[] Serialize(ProcessInfoPacket processInfoPacket)
		{
			List<byte> result = new List<byte>();

			// processName
			{
				byte[] processName = Encoding.UTF8.GetBytes(processInfoPacket.Name);
				result.Add(0x00);
				result.AddRange(BitConverter.GetBytes(processName.Length));
				result.AddRange(processName);
			}
			// processLocation
			{
				byte[] processLocation = Encoding.UTF8.GetBytes(processInfoPacket.Location);
				result.Add(0x01);
				result.AddRange(BitConverter.GetBytes(processLocation.Length));
				result.AddRange(processLocation);
			}
			// processIdentifier
			{
				result.Add(0x02);
				result.AddRange(BitConverter.GetBytes(sizeof(int)));
				result.AddRange(BitConverter.GetBytes(processInfoPacket.Identifier));
			}
			// processCPUUsage
			{
				result.Add(0x03);
				result.AddRange(BitConverter.GetBytes(sizeof(int)));
				result.AddRange(BitConverter.GetBytes(processInfoPacket.CPUUsage));
			}
			// processRAMUsage
			{
				result.Add(0x04);
				result.AddRange(BitConverter.GetBytes(sizeof(long)));
				result.AddRange(BitConverter.GetBytes(processInfoPacket.RAMUsage));
			}
			// processResponding
			{
				result.Add(0x05);
				result.AddRange(BitConverter.GetBytes(sizeof(bool)));
				result.AddRange(BitConverter.GetBytes(processInfoPacket.Responding));
			}
			// processIsService
			{
				result.Add(0x06);
				result.AddRange(BitConverter.GetBytes(sizeof(bool)));
				result.AddRange(BitConverter.GetBytes(processInfoPacket.IsService));
			}

			return result.ToArray();
		}
	}
}
