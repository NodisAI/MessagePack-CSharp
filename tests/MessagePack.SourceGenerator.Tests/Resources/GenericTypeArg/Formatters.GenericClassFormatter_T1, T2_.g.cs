﻿// <auto-generated />

#pragma warning disable 618, 612, 414, 168, CS1591, SA1129, SA1309, SA1312, SA1403, SA1649

#pragma warning disable CS8669 // We may leak nullable annotations into generated code.

namespace Formatters
{
	using MsgPack = global::MessagePack;

	internal sealed class GenericClassFormatter<T1, T2> : MsgPack::Formatters.IMessagePackFormatter<global::GenericClass<T1, T2>>
	{

		public void Serialize(ref MsgPack::MessagePackWriter writer, global::GenericClass<T1, T2> value, MsgPack::MessagePackSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNil();
				return;
			}

			MsgPack::IFormatterResolver formatterResolver = options.Resolver;
			writer.WriteArrayHeader(2);
			MsgPack::FormatterResolverExtensions.GetFormatterWithVerify<T1>(formatterResolver).Serialize(ref writer, value.MyProperty0, options);
			MsgPack::FormatterResolverExtensions.GetFormatterWithVerify<T2>(formatterResolver).Serialize(ref writer, value.MyProperty1, options);
		}

		public global::GenericClass<T1, T2> Deserialize(ref MsgPack::MessagePackReader reader, MsgPack::MessagePackSerializerOptions options)
		{
			if (reader.TryReadNil())
			{
				return null;
			}

			options.Security.DepthStep(ref reader);
			MsgPack::IFormatterResolver formatterResolver = options.Resolver;
			var length = reader.ReadArrayHeader();
			var ____result = new global::GenericClass<T1, T2>();

			for (int i = 0; i < length; i++)
			{
				switch (i)
				{
					case 0:
						____result.MyProperty0 = MsgPack::FormatterResolverExtensions.GetFormatterWithVerify<T1>(formatterResolver).Deserialize(ref reader, options);
						break;
					case 1:
						____result.MyProperty1 = MsgPack::FormatterResolverExtensions.GetFormatterWithVerify<T2>(formatterResolver).Deserialize(ref reader, options);
						break;
					default:
						reader.Skip();
						break;
				}
			}

			reader.Depth--;
			return ____result;
		}
	}
}
