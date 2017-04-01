# Statistics

Total codebase size: 497330

Code to analyze: 26633

Total size of duplicated fragments: 54865

# Detected Duplicates

## Duplicated Code. Size: 1024

### Duplicated Fragments:

Fragment 1 in file Server\Items\Container.cs

<pre>{
			if (types.Length != amounts.Length)
			{
				throw new ArgumentException();
			}
			else if (grouper == null)
			{
				throw new ArgumentNullException();
			}

			var items = new Item[types.Length][][];
			var totals = new int[types.Length][];

			for (int i = 0; i < types.Length; ++i)
			{
				var typedItems = FindItemsByType(types[i], recurse);

				var groups = new List<List<Item>>();
				int idx = 0;

				while (idx < typedItems.Length)
				{
					Item a = typedItems[idx++];
					var group = new List<Item>();

					group.Add(a);

					while (idx < typedItems.Length)
					{
						Item b = typedItems[idx];
						int v = grouper(a, b);

						if (v == 0)
						{
							group.Add(b);
						}
						else
						{
							break;
						}

						++idx;
					}

					groups.Add(group);
				}

				items[i] = new Item[groups.Count][];
				totals[i] = new int[groups.Count];

				bool hasEnough = false;

				for (int j = 0; j < groups.Count; ++j)
				{
					items[i][j] = groups[j].ToArray();
					//items[i][j] = (Item[])(((ArrayList)groups[j]).ToArray( typeof( Item ) ));

					for (int k = 0; k < items[i][j].Length; ++k)
					{
						totals[i][j] += items[i][j][k].Amount;
					}

					if (totals[i][j] >= amounts[i])
					{
						hasEnough = true;
					}
				}

				if (!hasEnough)
				{
					return i;
				}
			}

			for (int i = 0; i < items.Length; ++i)
			{
				for (int j = 0; j < items[i].Length; ++j)
				{
					if (totals[i][j] >= amounts[i])
					{
						int need = amounts[i];

						for (int k = 0; k < items[i][j].Length; ++k)
						{
							Item item = items[i][j][k];

							int theirAmount = item.Amount;

							if (theirAmount < need)
							{
								if (callback != null)
								{
									callback(item, theirAmount);
								}

								item.Delete();
								need -= theirAmount;
							}
							else
							{
								if (callback != null)
								{
									callback(item, need);
								}

								item.Consume(need);
								break;
							}
						}

						break;
					}
				}
			}

			return -1;
		}</pre>

Fragment 2 in file Server\Items\Container.cs

<pre>{
			if (types.Length != amounts.Length)
			{
				throw new ArgumentException();
			}
			else if (grouper == null)
			{
				throw new ArgumentNullException();
			}

			var items = new Item[types.Length][][];
			var totals = new int[types.Length][];

			for (int i = 0; i < types.Length; ++i)
			{
				var typedItems = FindItemsByType(types[i], recurse);

				var groups = new List<List<Item>>();
				int idx = 0;

				while (idx < typedItems.Length)
				{
					Item a = typedItems[idx++];
					var group = new List<Item>();

					group.Add(a);

					while (idx < typedItems.Length)
					{
						Item b = typedItems[idx];
						int v = grouper(a, b);

						if (v == 0)
						{
							group.Add(b);
						}
						else
						{
							break;
						}

						++idx;
					}

					groups.Add(group);
				}

				items[i] = new Item[groups.Count][];
				totals[i] = new int[groups.Count];

				bool hasEnough = false;

				for (int j = 0; j < groups.Count; ++j)
				{
					items[i][j] = groups[j].ToArray();

					for (int k = 0; k < items[i][j].Length; ++k)
					{
						totals[i][j] += items[i][j][k].Amount;
					}

					if (totals[i][j] >= amounts[i])
					{
						hasEnough = true;
					}
				}

				if (!hasEnough)
				{
					return i;
				}
			}

			for (int i = 0; i < items.Length; ++i)
			{
				for (int j = 0; j < items[i].Length; ++j)
				{
					if (totals[i][j] >= amounts[i])
					{
						int need = amounts[i];

						for (int k = 0; k < items[i][j].Length; ++k)
						{
							Item item = items[i][j][k];

							int theirAmount = item.Amount;

							if (theirAmount < need)
							{
								if (callback != null)
								{
									callback(item, theirAmount);
								}

								item.Delete();
								need -= theirAmount;
							}
							else
							{
								if (callback != null)
								{
									callback(item, need);
								}

								item.Consume(need);
								break;
							}
						}

						break;
					}
				}
			}

			return -1;
		}</pre>

## Duplicated Code. Size: 869

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)Notoriety.Compute(beholder, beheld));

			for (int i = 0; i < eq.Count; ++i)
			{
				Item item = eq[i];

				byte layer = (byte)item.Layer;

				if (!item.Deleted && beholder.CanSee(item) && m_DupedLayers[layer] != m_Version)
				{
					m_DupedLayers[layer] = m_Version;

					hue = item.Hue;

					if (beheld.SolidHueOverride >= 0)
					{
						hue = beheld.SolidHueOverride;
					}

					int itemID = item.ItemID & 0x7FFF;
					bool writeHue = (hue != 0);

					if (writeHue)
					{
						itemID |= 0x8000;
					}

					m_Stream.Write(item.Serial);
					m_Stream.Write((ushort)itemID);
					m_Stream.Write(layer);

					if (writeHue)
					{
						m_Stream.Write((short)hue);
					}
				}
			}

			if (beheld.HairItemID > 0)
			{
				if (m_DupedLayers[(int)Layer.Hair] != m_Version)
				{
					m_DupedLayers[(int)Layer.Hair] = m_Version;
					hue = beheld.HairHue;

					if (beheld.SolidHueOverride >= 0)
					{
						hue = beheld.SolidHueOverride;
					}

					int itemID = beheld.HairItemID & 0x7FFF;

					bool writeHue = (hue != 0);

					if (writeHue)
					{
						itemID |= 0x8000;
					}

					m_Stream.Write(HairInfo.FakeSerial(beheld));
					m_Stream.Write((ushort)itemID);
					m_Stream.Write((byte)Layer.Hair);

					if (writeHue)
					{
						m_Stream.Write((short)hue);
					}
				}
			}

			if (beheld.FacialHairItemID > 0)
			{
				if (m_DupedLayers[(int)Layer.FacialHair] != m_Version)
				{
					m_DupedLayers[(int)Layer.FacialHair] = m_Version;
					hue = beheld.FacialHairHue;

					if (beheld.SolidHueOverride >= 0)
					{
						hue = beheld.SolidHueOverride;
					}

					int itemID = beheld.FacialHairItemID & 0x7FFF;

					bool writeHue = (hue != 0);

					if (writeHue)
					{
						itemID |= 0x8000;
					}

					m_Stream.Write(FacialHairInfo.FakeSerial(beheld));
					m_Stream.Write((ushort)itemID);
					m_Stream.Write((byte)Layer.FacialHair);

					if (writeHue)
					{
						m_Stream.Write((short)hue);
					}
				}
			}

			m_Stream.Write(0); // terminate</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)Notoriety.Compute(beholder, beheld));

			for (int i = 0; i < eq.Count; ++i)
			{
				Item item = eq[i];

				byte layer = (byte)item.Layer;

				if (!item.Deleted && beholder.CanSee(item) && m_DupedLayers[layer] != m_Version)
				{
					m_DupedLayers[layer] = m_Version;

					hue = item.Hue;

					if (beheld.SolidHueOverride >= 0)
					{
						hue = beheld.SolidHueOverride;
					}

					int itemID = item.ItemID & 0x7FFF;
					bool writeHue = (hue != 0);

					if (writeHue)
					{
						itemID |= 0x8000;
					}

					m_Stream.Write(item.Serial);
					m_Stream.Write((ushort)itemID);
					m_Stream.Write(layer);

					if (writeHue)
					{
						m_Stream.Write((short)hue);
					}
				}
			}

			if (beheld.HairItemID > 0)
			{
				if (m_DupedLayers[(int)Layer.Hair] != m_Version)
				{
					m_DupedLayers[(int)Layer.Hair] = m_Version;
					hue = beheld.HairHue;

					if (beheld.SolidHueOverride >= 0)
					{
						hue = beheld.SolidHueOverride;
					}

					int itemID = beheld.HairItemID & 0x7FFF;

					bool writeHue = (hue != 0);

					if (writeHue)
					{
						itemID |= 0x8000;
					}

					m_Stream.Write(HairInfo.FakeSerial(beheld));
					m_Stream.Write((ushort)itemID);
					m_Stream.Write((byte)Layer.Hair);

					if (writeHue)
					{
						m_Stream.Write((short)hue);
					}
				}
			}

			if (beheld.FacialHairItemID > 0)
			{
				if (m_DupedLayers[(int)Layer.FacialHair] != m_Version)
				{
					m_DupedLayers[(int)Layer.FacialHair] = m_Version;
					hue = beheld.FacialHairHue;

					if (beheld.SolidHueOverride >= 0)
					{
						hue = beheld.SolidHueOverride;
					}

					int itemID = beheld.FacialHairItemID & 0x7FFF;

					bool writeHue = (hue != 0);

					if (writeHue)
					{
						itemID |= 0x8000;
					}

					m_Stream.Write(FacialHairInfo.FakeSerial(beheld));
					m_Stream.Write((ushort)itemID);
					m_Stream.Write((byte)Layer.FacialHair);

					if (writeHue)
					{
						m_Stream.Write((short)hue);
					}
				}
			}

			m_Stream.Write(0); // terminate</pre>

## Duplicated Code. Size: 499

### Duplicated Fragments:

Fragment 1 in file Server\Items\Container.cs

<pre>{
			if (types.Length != amounts.Length)
			{
				throw new ArgumentException();
			}

			var items = new Item[types.Length][];
			var totals = new int[types.Length];

			for (int i = 0; i < types.Length; ++i)
			{
				items[i] = FindItemsByType(types[i], recurse);

				for (int j = 0; j < items[i].Length; ++j)
				{
					totals[i] += items[i][j].Amount;
				}

				if (totals[i] < amounts[i])
				{
					return i;
				}
			}

			for (int i = 0; i < types.Length; ++i)
			{
				int need = amounts[i];

				for (int j = 0; j < items[i].Length; ++j)
				{
					Item item = items[i][j];

					int theirAmount = item.Amount;

					if (theirAmount < need)
					{
						if (callback != null)
						{
							callback(item, theirAmount);
						}

						item.Delete();
						need -= theirAmount;
					}
					else
					{
						if (callback != null)
						{
							callback(item, need);
						}

						item.Consume(need);
						break;
					}
				}
			}

			return -1;
		}</pre>

Fragment 2 in file Server\Items\Container.cs

<pre>{
			if (types.Length != amounts.Length)
			{
				throw new ArgumentException();
			}

			var items = new Item[types.Length][];
			var totals = new int[types.Length];

			for (int i = 0; i < types.Length; ++i)
			{
				items[i] = FindItemsByType(types[i], recurse);

				for (int j = 0; j < items[i].Length; ++j)
				{
					totals[i] += items[i][j].Amount;
				}

				if (totals[i] < amounts[i])
				{
					return i;
				}
			}

			for (int i = 0; i < types.Length; ++i)
			{
				int need = amounts[i];

				for (int j = 0; j < items[i].Length; ++j)
				{
					Item item = items[i][j];

					int theirAmount = item.Amount;

					if (theirAmount < need)
					{
						if (callback != null)
						{
							callback(item, theirAmount);
						}

						item.Delete();
						need -= theirAmount;
					}
					else
					{
						if (callback != null)
						{
							callback(item, need);
						}

						item.Consume(need);
						break;
					}
				}
			}

			return -1;
		}</pre>

## Duplicated Code. Size: 487

### Duplicated Fragments:

Fragment 1 in file Server\MultiData.cs

<pre>var tiles = new TileList[m_Width][];
			m_Tiles = new StaticTile[m_Width][][];

			for (int x = 0; x < m_Width; ++x)
			{
				tiles[x] = new TileList[m_Height];
				m_Tiles[x] = new StaticTile[m_Height][];

				for (int y = 0; y < m_Height; ++y)
				{
					tiles[x][y] = new TileList();
				}
			}

			for (int i = 0; i < allTiles.Length; ++i)
			{
				if (i == 0 || allTiles[i].m_Flags != 0)
				{
					int xOffset = allTiles[i].m_OffsetX + m_Center.m_X;
					int yOffset = allTiles[i].m_OffsetY + m_Center.m_Y;

					#region Stygian Abyss
					//tiles[xOffset][yOffset].Add( (ushort)allTiles[i].m_ItemID, (sbyte)allTiles[i].m_OffsetZ );
					tiles[xOffset][yOffset].Add(
						(ushort)((allTiles[i].m_ItemID & TileData.MaxItemValue) | 0x10000), (sbyte)allTiles[i].m_OffsetZ);
					#endregion
				}
			}

			for (int x = 0; x < m_Width; ++x)
			{
				for (int y = 0; y < m_Height; ++y)
				{
					m_Tiles[x][y] = tiles[x][y].ToArray();
				}
			}</pre>

Fragment 2 in file Server\MultiData.cs

<pre>var tiles = new TileList[m_Width][];
			m_Tiles = new StaticTile[m_Width][][];

			for (int x = 0; x < m_Width; ++x)
			{
				tiles[x] = new TileList[m_Height];
				m_Tiles[x] = new StaticTile[m_Height][];

				for (int y = 0; y < m_Height; ++y)
				{
					tiles[x][y] = new TileList();
				}
			}

			for (int i = 0; i < allTiles.Length; ++i)
			{
				if (i == 0 || allTiles[i].m_Flags != 0)
				{
					int xOffset = allTiles[i].m_OffsetX + m_Center.m_X;
					int yOffset = allTiles[i].m_OffsetY + m_Center.m_Y;

					#region Stygian Abyss
					//tiles[xOffset][yOffset].Add( (ushort)allTiles[i].m_ItemID, (sbyte)allTiles[i].m_OffsetZ );
					tiles[xOffset][yOffset].Add(
						(ushort)((allTiles[i].m_ItemID & TileData.MaxItemValue) | 0x10000), (sbyte)allTiles[i].m_OffsetZ);
					#endregion
				}
			}

			for (int x = 0; x < m_Width; ++x)
			{
				for (int y = 0; y < m_Height; ++y)
				{
					m_Tiles[x][y] = tiles[x][y].ToArray();
				}
			}</pre>

## Duplicated Code. Size: 435

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>long pos = m_Stream.Position;

			int written = 0;

			m_Stream.Write((ushort)0);

			for (int i = 0; i < count; ++i)
			{
				Item child = items[i];

				if (!child.Deleted && beholder.CanSee(child))
				{
                    if (child.GridLocation == 0xFF)
                    {
                        child.GridLocation = (byte)(count - written);
                    }

                    Point3D loc = child.Location;

					m_Stream.Write(child.Serial);
					m_Stream.Write((ushort)child.ItemID);
					m_Stream.Write((byte)0); // signed, itemID offset
					m_Stream.Write((ushort)child.Amount);
					m_Stream.Write((short)loc.m_X);
					m_Stream.Write((short)loc.m_Y);
                    m_Stream.Write((byte)child.GridLocation);
                    m_Stream.Write(beheld.Serial);
					m_Stream.Write((ushort)(child.QuestItem ? Item.QuestItemHue : child.Hue));

					++written;
				}
			}

			m_Stream.Seek(pos, SeekOrigin.Begin);
			m_Stream.Write((ushort)written);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>long pos = m_Stream.Position;

			int written = 0;

			m_Stream.Write((ushort)0);

			for (int i = 0; i < count; ++i)
			{
				Item child = items[i];

				if (!child.Deleted && beholder.CanSee(child))
				{
                    Point3D loc = child.Location;

                    if (child.GridLocation == 0xFF)
                    {
                        child.GridLocation = (byte)(count - written);
                    }

                    m_Stream.Write(child.Serial);
					m_Stream.Write((ushort)child.ItemID);
					m_Stream.Write((byte)0); // signed, itemID offset
					m_Stream.Write((ushort)child.Amount);
					m_Stream.Write((short)loc.m_X);
					m_Stream.Write((short)loc.m_Y);
                    m_Stream.Write((byte)child.GridLocation);
                    m_Stream.Write(beheld.Serial);
					m_Stream.Write((ushort)(child.QuestItem ? Item.QuestItemHue : child.Hue));

					++written;
				}
			}

			m_Stream.Seek(pos, SeekOrigin.Begin);
			m_Stream.Write((ushort)written);</pre>

## Duplicated Code. Size: 406

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>{
			Serial serial = pvSrc.ReadInt32(); // serial, ignored
			int x = pvSrc.ReadInt16();
			int y = pvSrc.ReadInt16();
			int z = pvSrc.ReadSByte();
            byte gridloc = pvSrc.ReadByte(); // grid location
            Serial dest = pvSrc.ReadInt32();

			Point3D loc = new Point3D(x, y, z);
			Mobile from = state.Mobile;

            if (serial.IsItem)
            {
                Item dropped = World.FindItem(serial);

                if (dropped != null)
                {
                    dropped.GridLocation = gridloc;
                }
            }

			if (dest.IsMobile)
			{
				from.Drop(World.FindMobile(dest), loc);
			}
			else if (dest.IsItem)
			{
				Item item = World.FindItem(dest);

				if (item is BaseMulti && ((BaseMulti)item).AllowsRelativeDrop)
				{
					loc.m_X += item.X;
					loc.m_Y += item.Y;
					from.Drop(loc);
				}
				else
				{
					from.Drop(item, loc);
				}
			}
			else
			{
				from.Drop(loc);
			}
		}</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>{
            Serial serial = pvSrc.ReadInt32();
            int x = pvSrc.ReadInt16();
			int y = pvSrc.ReadInt16();
			int z = pvSrc.ReadSByte();
            byte gridloc = pvSrc.ReadByte(); // grid location
            Serial dest = pvSrc.ReadInt32();

			Point3D loc = new Point3D(x, y, z);
			Mobile from = state.Mobile;

            if (serial.IsItem)
            {
                Item dropped = World.FindItem(serial);

                if (dropped != null)
                {
                    dropped.GridLocation = gridloc;
                }
            }

			if (dest.IsMobile)
			{
				from.Drop(World.FindMobile(dest), loc);
			}
			else if (dest.IsItem)
			{
				Item item = World.FindItem(dest);

				if (item is BaseMulti && ((BaseMulti)item).AllowsRelativeDrop)
				{
					loc.m_X += item.X;
					loc.m_Y += item.Y;
					from.Drop(loc);
				}
				else
				{
					from.Drop(item, loc);
				}
			}
			else
			{
				from.Drop(loc);
			}
		}</pre>

## Duplicated Code. Size: 403

### Duplicated Fragments:

Fragment 1 in file Server\Network\Compression.cs

<pre>public sealed class Compressor32 : ICompressor
	{
		internal class SafeNativeMethods
		{
			[DllImport("zlibwapi32")]
			internal static extern string zlibVersion();

			[DllImport("zlibwapi32")]
			internal static extern ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

			[DllImport("zlibwapi32")]
			internal static extern ZLibError compress2(
				byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality);

			[DllImport("zlibwapi32")]
			internal static extern ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);
		}

		public string Version { get { return SafeNativeMethods.zlibVersion(); } }

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.compress(dest, ref destLength, source, sourceLength);
		}

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			return SafeNativeMethods.compress2(dest, ref destLength, source, sourceLength, quality);
		}

		public ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.uncompress(dest, ref destLength, source, sourceLength);
		}
	}</pre>

Fragment 2 in file Server\Network\Compression.cs

<pre>public sealed class Compressor64 : ICompressor
	{
		internal class SafeNativeMethods
		{
			[DllImport("zlibwapi64")]
			internal static extern string zlibVersion();

			[DllImport("zlibwapi64")]
			internal static extern ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

			[DllImport("zlibwapi64")]
			internal static extern ZLibError compress2(
				byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality);

			[DllImport("zlibwapi64")]
			internal static extern ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);
		}

		public string Version { get { return SafeNativeMethods.zlibVersion(); } }

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.compress(dest, ref destLength, source, sourceLength);
		}

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			return SafeNativeMethods.compress2(dest, ref destLength, source, sourceLength, quality);
		}

		public ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.uncompress(dest, ref destLength, source, sourceLength);
		}
	}</pre>

Fragment 3 in file Server\Network\Compression.cs

<pre>public sealed class CompressorUnix32 : ICompressor
	{
		internal class SafeNativeMethods
		{
			[DllImport("libz")]
			internal static extern string zlibVersion();

			[DllImport("libz")]
			internal static extern ZLibError compress(byte[] dest, ref int destLength, byte[] source, int sourceLength);

			[DllImport("libz")]
			internal static extern ZLibError compress2(
				byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality);

			[DllImport("libz")]
			internal static extern ZLibError uncompress(byte[] dest, ref int destLen, byte[] source, int sourceLen);
		}

		public string Version { get { return SafeNativeMethods.zlibVersion(); } }

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.compress(dest, ref destLength, source, sourceLength);
		}

		public ZLibError Compress(byte[] dest, ref int destLength, byte[] source, int sourceLength, ZLibQuality quality)
		{
			return SafeNativeMethods.compress2(dest, ref destLength, source, sourceLength, quality);
		}

		public ZLibError Decompress(byte[] dest, ref int destLength, byte[] source, int sourceLength)
		{
			return SafeNativeMethods.uncompress(dest, ref destLength, source, sourceLength);
		}
	}</pre>

## Duplicated Code. Size: 370

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>int unk1 = pvSrc.ReadInt32();
			int unk2 = pvSrc.ReadInt32();
			int unk3 = pvSrc.ReadByte();
			string name = pvSrc.ReadString(30);

			pvSrc.Seek(2, SeekOrigin.Current);
			int flags = pvSrc.ReadInt32();
			pvSrc.Seek(8, SeekOrigin.Current);
			int prof = pvSrc.ReadByte();
			pvSrc.Seek(15, SeekOrigin.Current);

			//bool female = pvSrc.ReadBoolean();

			int genderRace = pvSrc.ReadByte();

			int str = pvSrc.ReadByte();
			int dex = pvSrc.ReadByte();
			int intl = pvSrc.ReadByte();
			int is1 = pvSrc.ReadByte();
			int vs1 = pvSrc.ReadByte();
			int is2 = pvSrc.ReadByte();
			int vs2 = pvSrc.ReadByte();
			int is3 = pvSrc.ReadByte();
			int vs3 = pvSrc.ReadByte();</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>int unk1 = pvSrc.ReadInt32();
			int unk2 = pvSrc.ReadInt32();
			int unk3 = pvSrc.ReadByte();
			string name = pvSrc.ReadString(30);

			pvSrc.Seek(2, SeekOrigin.Current);
			int flags = pvSrc.ReadInt32();
			pvSrc.Seek(8, SeekOrigin.Current);
			int prof = pvSrc.ReadByte();
			pvSrc.Seek(15, SeekOrigin.Current);

			int genderRace = pvSrc.ReadByte();

			int str = pvSrc.ReadByte();
			int dex = pvSrc.ReadByte();
			int intl = pvSrc.ReadByte();
			int is1 = pvSrc.ReadByte();
			int vs1 = pvSrc.ReadByte();
			int is2 = pvSrc.ReadByte();
			int vs2 = pvSrc.ReadByte();
			int is3 = pvSrc.ReadByte();
			int vs3 = pvSrc.ReadByte();</pre>

## Duplicated Code. Size: 368

### Duplicated Fragments:

Fragment 1 in file Server\Items\Container.cs

<pre>var groups = new List<List<Item>>();
			int idx = 0;

			while (idx < typedItems.Length)
			{
				Item a = typedItems[idx++];
				var group = new List<Item>();

				group.Add(a);

				while (idx < typedItems.Length)
				{
					Item b = typedItems[idx];
					int v = grouper(a, b);

					if (v == 0)
					{
						group.Add(b);
					}
					else
					{
						break;
					}

					++idx;
				}

				groups.Add(group);
			}

			for (int j = 0; j < groups.Count; ++j)
			{
				var items = groups[j].ToArray();
				//Item[] items = (Item[])(((ArrayList)groups[j]).ToArray( typeof( Item ) ));
				int total = 0;

				for (int k = 0; k < items.Length; ++k)
				{
					total += items[k].Amount;
				}

				if (total >= best)
				{
					best = total;
				}
			}</pre>

Fragment 2 in file Server\Items\Container.cs

<pre>var groups = new List<List<Item>>();
				int idx = 0;

				while (idx < typedItems.Length)
				{
					Item a = typedItems[idx++];
					var group = new List<Item>();

					group.Add(a);

					while (idx < typedItems.Length)
					{
						Item b = typedItems[idx];
						int v = grouper(a, b);

						if (v == 0)
						{
							group.Add(b);
						}
						else
						{
							break;
						}

						++idx;
					}

					groups.Add(group);
				}

				for (int j = 0; j < groups.Count; ++j)
				{
					var items = groups[j].ToArray();
					//Item[] items = (Item[])(((ArrayList)groups[j]).ToArray( typeof( Item ) ));
					int total = 0;

					for (int k = 0; k < items.Length; ++k)
					{
						total += items[k].Amount;
					}

					if (total >= best)
					{
						best = total;
					}
				}</pre>

## Duplicated Code. Size: 359

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.Layer))
                        {
                            m_Layer = (Layer)reader.ReadByte();
                        }

                        if (GetSaveFlag(flags, SaveFlag.Name))
                        {
                            string name = reader.ReadString();

                            if (name != DefaultName)
                            {
                                AcquireCompactInfo().m_Name = name;
                            }
                        }

                        if (GetSaveFlag(flags, SaveFlag.Parent))
                        {
                            Serial parent = reader.ReadInt();

                            if (parent.IsMobile)
                            {
                                m_Parent = World.FindMobile(parent);
                            }
                            else if (parent.IsItem)
                            {
                                m_Parent = World.FindItem(parent);
                            }
                            else
                            {
                                m_Parent = null;
                            }

                            if (m_Parent == null && (parent.IsMobile || parent.IsItem))
                            {
                                Delete();
                            }
                        }

                        if (GetSaveFlag(flags, SaveFlag.Items))
                        {
                            var items = reader.ReadStrongItemList();

                            if (this is Container)
                            {
                                (this as Container).m_Items = items;
                            }
                            else
                            {
                                AcquireCompactInfo().m_Items = items;
                            }
                        }</pre>

Fragment 2 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.Layer))
                        {
                            m_Layer = (Layer)reader.ReadByte();
                        }

                        if (GetSaveFlag(flags, SaveFlag.Name))
                        {
                            string name = reader.ReadString();

                            if (name != DefaultName)
                            {
                                AcquireCompactInfo().m_Name = name;
                            }
                        }

                        if (GetSaveFlag(flags, SaveFlag.Parent))
                        {
                            Serial parent = reader.ReadInt();

                            if (parent.IsMobile)
                            {
                                m_Parent = World.FindMobile(parent);
                            }
                            else if (parent.IsItem)
                            {
                                m_Parent = World.FindItem(parent);
                            }
                            else
                            {
                                m_Parent = null;
                            }

                            if (m_Parent == null && (parent.IsMobile || parent.IsItem))
                            {
                                Delete();
                            }
                        }

                        if (GetSaveFlag(flags, SaveFlag.Items))
                        {
                            var items = reader.ReadStrongItemList();

                            if (this is Container)
                            {
                                (this as Container).m_Items = items;
                            }
                            else
                            {
                                AcquireCompactInfo().m_Items = items;
                            }
                        }</pre>

## Duplicated Code. Size: 358

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>ThirdPartyFeature disabled = FeatureProtection.DisabledFeatures;

			if (disabled != 0)
			{
				if (m_MD5Provider == null)
				{
					m_MD5Provider = new MD5CryptoServiceProvider();
				}

				m_Stream.UnderlyingStream.Flush();

				var hashCode = m_MD5Provider.ComputeHash(
					m_Stream.UnderlyingStream.GetBuffer(), 0, (int)m_Stream.UnderlyingStream.Length);
				var buffer = new byte[28];

				for (int i = 0; i < count; ++i)
				{
					Utility.RandomBytes(buffer);

					m_Stream.Seek(35 + (i * 60), SeekOrigin.Begin);
					m_Stream.Write(buffer, 0, buffer.Length);
				}

				m_Stream.Seek(35, SeekOrigin.Begin);
				m_Stream.Write((int)((long)disabled >> 32));
				m_Stream.Write((int)disabled);

				m_Stream.Seek(95, SeekOrigin.Begin);
				m_Stream.Write(hashCode, 0, hashCode.Length);
			}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>ThirdPartyFeature disabled = FeatureProtection.DisabledFeatures;

			if (disabled != 0)
			{
				if (m_MD5Provider == null)
				{
					m_MD5Provider = new MD5CryptoServiceProvider();
				}

				m_Stream.UnderlyingStream.Flush();

				var hashCode = m_MD5Provider.ComputeHash(
					m_Stream.UnderlyingStream.GetBuffer(), 0, (int)m_Stream.UnderlyingStream.Length);
				var buffer = new byte[28];

				for (int i = 0; i < count; ++i)
				{
					Utility.RandomBytes(buffer);

					m_Stream.Seek(35 + (i * 60), SeekOrigin.Begin);
					m_Stream.Write(buffer, 0, buffer.Length);
				}

				m_Stream.Seek(35, SeekOrigin.Begin);
				m_Stream.Write((int)((long)disabled >> 32));
				m_Stream.Write((int)disabled);

				m_Stream.Seek(95, SeekOrigin.Begin);
				m_Stream.Write(hashCode, 0, hashCode.Length);
			}</pre>

## Duplicated Code. Size: 356

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Beheld = beheld;

			int m_Version = ++(m_VersionTL.Value);
			var m_DupedLayers = m_DupedLayersTL.Value;

			var eq = beheld.Items;
			int count = eq.Count;

			if (beheld.HairItemID > 0)
			{
				count++;
			}
			if (beheld.FacialHairItemID > 0)
			{
				count++;
			}

			EnsureCapacity(23 + (count * 9));

			int hue = beheld.Hue;

			if (beheld.SolidHueOverride >= 0)
			{
				hue = beheld.SolidHueOverride;
			}

			m_Stream.Write(beheld.Serial);
			m_Stream.Write((short)beheld.Body);
			m_Stream.Write((short)beheld.X);
			m_Stream.Write((short)beheld.Y);
			m_Stream.Write((sbyte)beheld.Z);
			m_Stream.Write((byte)beheld.Direction);
			m_Stream.Write((short)hue);
			m_Stream.Write((byte)beheld.GetPacketFlags());</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Beheld = beheld;

			int m_Version = ++(m_VersionTL.Value);
			var m_DupedLayers = m_DupedLayersTL.Value;

			var eq = beheld.Items;
			int count = eq.Count;

			if (beheld.HairItemID > 0)
			{
				count++;
			}
			if (beheld.FacialHairItemID > 0)
			{
				count++;
			}

			EnsureCapacity(23 + (count * 9));

			int hue = beheld.Hue;

			if (beheld.SolidHueOverride >= 0)
			{
				hue = beheld.SolidHueOverride;
			}

			m_Stream.Write(beheld.Serial);
			m_Stream.Write((short)beheld.Body);
			m_Stream.Write((short)beheld.X);
			m_Stream.Write((short)beheld.Y);
			m_Stream.Write((sbyte)beheld.Z);
			m_Stream.Write((byte)beheld.Direction);
			m_Stream.Write((short)hue);
			m_Stream.Write((byte)beheld.GetPacketFlags());</pre>

## Duplicated Code. Size: 328

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)type);
			m_Stream.Write(@from);
			m_Stream.Write(to);
			m_Stream.Write((short)itemID);
			m_Stream.Write((short)fromPoint.m_X);
			m_Stream.Write((short)fromPoint.m_Y);
			m_Stream.Write((sbyte)fromPoint.m_Z);
			m_Stream.Write((short)toPoint.m_X);
			m_Stream.Write((short)toPoint.m_Y);
			m_Stream.Write((sbyte)toPoint.m_Z);
			m_Stream.Write((byte)speed);
			m_Stream.Write((byte)duration);
			m_Stream.Write((byte)0);
			m_Stream.Write((byte)0);
			m_Stream.Write(fixedDirection);
			m_Stream.Write(explode);
			m_Stream.Write(hue);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)type);
			m_Stream.Write(@from);
			m_Stream.Write(to);
			m_Stream.Write((short)itemID);
			m_Stream.Write((short)fromPoint.m_X);
			m_Stream.Write((short)fromPoint.m_Y);
			m_Stream.Write((sbyte)fromPoint.m_Z);
			m_Stream.Write((short)toPoint.m_X);
			m_Stream.Write((short)toPoint.m_Y);
			m_Stream.Write((sbyte)toPoint.m_Z);
			m_Stream.Write((byte)speed);
			m_Stream.Write((byte)duration);
			m_Stream.Write((byte)0);
			m_Stream.Write((byte)0);
			m_Stream.Write(fixedDirection);
			m_Stream.Write(explode);
			m_Stream.Write(hue);</pre>

## Duplicated Code. Size: 328

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)type);
			m_Stream.Write(@from);
			m_Stream.Write(to);
			m_Stream.Write((short)itemID);
			m_Stream.Write((short)fromPoint.X);
			m_Stream.Write((short)fromPoint.Y);
			m_Stream.Write((sbyte)fromPoint.Z);
			m_Stream.Write((short)toPoint.X);
			m_Stream.Write((short)toPoint.Y);
			m_Stream.Write((sbyte)toPoint.Z);
			m_Stream.Write((byte)speed);
			m_Stream.Write((byte)duration);
			m_Stream.Write((byte)0);
			m_Stream.Write((byte)0);
			m_Stream.Write(fixedDirection);
			m_Stream.Write(explode);
			m_Stream.Write(hue);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)type);
			m_Stream.Write(@from);
			m_Stream.Write(to);
			m_Stream.Write((short)itemID);
			m_Stream.Write((short)fromPoint.X);
			m_Stream.Write((short)fromPoint.Y);
			m_Stream.Write((sbyte)fromPoint.Z);
			m_Stream.Write((short)toPoint.X);
			m_Stream.Write((short)toPoint.Y);
			m_Stream.Write((sbyte)toPoint.Z);
			m_Stream.Write((byte)speed);
			m_Stream.Write((byte)duration);
			m_Stream.Write((byte)0);
			m_Stream.Write((byte)0);
			m_Stream.Write(fixedDirection);
			m_Stream.Write(explode);
			m_Stream.Write(hue);</pre>

## Duplicated Code. Size: 287

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>{
			if ((m_Index + 8) > m_Buffer.Length)
			{
				Flush();
			}

			m_Buffer[m_Index] = (byte)value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Buffer[m_Index + 4] = (byte)(value >> 32);
			m_Buffer[m_Index + 5] = (byte)(value >> 40);
			m_Buffer[m_Index + 6] = (byte)(value >> 48);
			m_Buffer[m_Index + 7] = (byte)(value >> 56);
			m_Index += 8;
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>{
			if ((m_Index + 8) > m_Buffer.Length)
			{
				Flush();
			}

			m_Buffer[m_Index] = (byte)value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Buffer[m_Index + 4] = (byte)(value >> 32);
			m_Buffer[m_Index + 5] = (byte)(value >> 40);
			m_Buffer[m_Index + 6] = (byte)(value >> 48);
			m_Buffer[m_Index + 7] = (byte)(value >> 56);
			m_Index += 8;
		}</pre>

## Duplicated Code. Size: 285

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>{
			Serial parentSerial;

			if (item.Parent is Item)
			{
				parentSerial = ((Item)item.Parent).Serial;
			}
			else
			{
				Console.WriteLine("Warning: ContainerContentUpdate on item with !(parent is Item)");
				parentSerial = Serial.Zero;
			}

			m_Stream.Write(item.Serial);
			m_Stream.Write((ushort)item.ItemID);
			m_Stream.Write((byte)0); // signed, itemID offset
			m_Stream.Write((ushort)item.Amount);
			m_Stream.Write((short)item.X);
			m_Stream.Write((short)item.Y);
            m_Stream.Write((byte)item.GridLocation);
            m_Stream.Write(parentSerial);
			m_Stream.Write((ushort)(item.QuestItem ? Item.QuestItemHue : item.Hue));
		}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>{
			Serial parentSerial;

			if (item.Parent is Item)
			{
				parentSerial = ((Item)item.Parent).Serial;
			}
			else
			{
				Console.WriteLine("Warning: ContainerContentUpdate on item with !(parent is Item)");
				parentSerial = Serial.Zero;
			}

			m_Stream.Write(item.Serial);
			m_Stream.Write((ushort)item.ItemID);
			m_Stream.Write((byte)0); // signed, itemID offset
			m_Stream.Write((ushort)item.Amount);
			m_Stream.Write((short)item.X);
			m_Stream.Write((short)item.Y);
            m_Stream.Write((byte)item.GridLocation);
            m_Stream.Write(parentSerial);
			m_Stream.Write((ushort)(item.QuestItem ? Item.QuestItemHue : item.Hue));
		}</pre>

## Duplicated Code. Size: 277

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>int highSlot = -1;

			for (int i = 0; i < a.Length; ++i)
			{
				if (a[i] != null)
				{
					highSlot = i;
				}
			}

			int count = Math.Max(Math.Max(highSlot + 1, a.Limit), 5);

			m_Stream.Write((byte)count);

			for (int i = 0; i < count; ++i)
			{
				if (a[i] != null)
				{
					m_Stream.WriteAsciiFixed(a[i].Name, 30);
					m_Stream.Fill(30); // password
				}
				else
				{
					m_Stream.Fill(60);
				}
			}

			m_Stream.Write((byte)info.Length);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>int highSlot = -1;

			for (int i = 0; i < a.Length; ++i)
			{
				if (a[i] != null)
				{
					highSlot = i;
				}
			}

			int count = Math.Max(Math.Max(highSlot + 1, a.Limit), 5);

			m_Stream.Write((byte)count);

			for (int i = 0; i < count; ++i)
			{
				if (a[i] != null)
				{
					m_Stream.WriteAsciiFixed(a[i].Name, 30);
					m_Stream.Fill(30); // password
				}
				else
				{
					m_Stream.Fill(60);
				}
			}

			m_Stream.Write((byte)info.Length);</pre>

## Duplicated Code. Size: 258

### Duplicated Fragments:

Fragment 1 in file Server\Main.cs

<pre>if (
						t.GetMethod(
							"Serialize",
							BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly) == null)
					{
						if (warningSb == null)
						{
							warningSb = new StringBuilder();
						}

						warningSb.AppendLine("       - No Serialize() method");
					}

					if (
						t.GetMethod(
							"Deserialize",
							BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly) == null)
					{
						if (warningSb == null)
						{
							warningSb = new StringBuilder();
						}

						warningSb.AppendLine("       - No Deserialize() method");
					}

					if (warningSb != null && warningSb.Length > 0)
					{
						Utility.PushColor(ConsoleColor.Yellow);
						Console.WriteLine("Warning: {0}\n{1}", t, warningSb);
						Utility.PopColor();
					}</pre>

Fragment 2 in file Server\Main.cs

<pre>if (
						t.GetMethod(
							"Serialize",
							BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly) == null)
					{
						if (warningSb == null)
						{
							warningSb = new StringBuilder();
						}

						warningSb.AppendLine("       - No Serialize() method");
					}

					if (
						t.GetMethod(
							"Deserialize",
							BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly) == null)
					{
						if (warningSb == null)
						{
							warningSb = new StringBuilder();
						}

						warningSb.AppendLine("       - No Deserialize() method");
					}

					if (warningSb != null && warningSb.Length > 0)
					{
						Utility.PushColor(ConsoleColor.Yellow);
						Console.WriteLine("Warning: {0}\n{1}", t, warningSb);
						Utility.PopColor();
					}</pre>

## Duplicated Code. Size: 257

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>var entries = menu.Entries;

			int length = (byte)entries.Length;

			EnsureCapacity(12 + (length * 8));

			m_Stream.Write((short)0x14);
			m_Stream.Write((short)0x02);

			IEntity target = menu.Target as IEntity;

			m_Stream.Write((target == null ? Serial.MinusOne : target.Serial));

			m_Stream.Write((byte)length);

			Point3D p;

			if (target is Mobile)
			{
				p = target.Location;
			}
			else if (target is Item)
			{
				p = ((Item)target).GetWorldLocation();
			}
			else
			{
				p = Point3D.Zero;
			}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>var entries = menu.Entries;

            int length = (byte)entries.Length;

            EnsureCapacity(12 + (length * 8));

            m_Stream.Write((short)0x14);
			m_Stream.Write((short)0x02); 

            IEntity target = menu.Target as IEntity;

			m_Stream.Write((target == null ? Serial.MinusOne : target.Serial));

			m_Stream.Write((byte)length);

			Point3D p;

			if (target is Mobile)
			{
				p = target.Location;
			}
			else if (target is Item)
			{
				p = ((Item)target).GetWorldLocation();
			}
			else
			{
				p = Point3D.Zero;
			}</pre>

## Duplicated Code. Size: 253

### Duplicated Fragments:

Fragment 1 in file Server\TileData.cs

<pre>{
								if ((i & 0x1F) == 0)
								{
									bin.ReadInt32(); // header
								}

								TileFlag flags = (TileFlag)bin.ReadInt32();
								int weight = bin.ReadByte();
								int quality = bin.ReadByte();
								bin.ReadInt16();
								bin.ReadByte();
								int quantity = bin.ReadByte();
								bin.ReadInt32();
								bin.ReadByte();
								int value = bin.ReadByte();
								int height = bin.ReadByte();

								m_ItemData[i] = new ItemData(ReadNameString(bin), flags, weight, quality, quantity, value, height);
							}</pre>

Fragment 2 in file Server\TileData.cs

<pre>{
								if ((i & 0x1F) == 0)
								{
									bin.ReadInt32(); // header
								}

								TileFlag flags = (TileFlag)bin.ReadInt32();
								int weight = bin.ReadByte();
								int quality = bin.ReadByte();
								bin.ReadInt16();
								bin.ReadByte();
								int quantity = bin.ReadByte();
								bin.ReadInt32();
								bin.ReadByte();
								int value = bin.ReadByte();
								int height = bin.ReadByte();

								m_ItemData[i] = new ItemData(ReadNameString(bin), flags, weight, quality, quantity, value, height);
							}</pre>

## Duplicated Code. Size: 247

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>SendEverything();
					SendIncomingPacket();

					if (ns != null)
					{
						ns.Sequence = 0;
						ClearFastwalkStack();

						ns.Send(MobileIncoming.Create(ns, this, this));

						if (ns.StygianAbyss)
						{
							ns.Send(SupportedFeatures.Instantiate(ns));
							ns.Send(new MobileUpdate(this));
							ns.Send(new MobileAttributes(this));
						}
						else
						{
							ns.Send(SupportedFeatures.Instantiate(ns));
							ns.Send(new MobileUpdateOld(this));
							ns.Send(new MobileAttributes(this));
						}
					}

					OnMapChange(oldMap);</pre>

Fragment 2 in file Server\Mobile.cs

<pre>SendEverything();
			SendIncomingPacket();

			if (ns != null)
			{
				ns.Sequence = 0;
				ClearFastwalkStack();

				ns.Send(MobileIncoming.Create(ns, this, this));

				if (ns.StygianAbyss)
				{
					ns.Send(SupportedFeatures.Instantiate(ns));
					ns.Send(new MobileUpdate(this));
					ns.Send(new MobileAttributes(this));
				}
				else
				{
					ns.Send(SupportedFeatures.Instantiate(ns));
					ns.Send(new MobileUpdateOld(this));
					ns.Send(new MobileAttributes(this));
				}
			}

			OnMapChange(oldMap);</pre>

## Duplicated Code. Size: 246

### Duplicated Fragments:

Fragment 1 in file Server\Items\Container.cs

<pre>var typedItems = FindItemsByType(type, recurse);

			var groups = new List<List<Item>>();
			int idx = 0;

			while (idx < typedItems.Length)
			{
				Item a = typedItems[idx++];
				var group = new List<Item>();

				group.Add(a);

				while (idx < typedItems.Length)
				{
					Item b = typedItems[idx];
					int v = grouper(a, b);

					if (v == 0)
					{
						group.Add(b);
					}
					else
					{
						break;
					}

					++idx;
				}

				groups.Add(group);
			}</pre>

Fragment 2 in file Server\Items\Container.cs

<pre>var typedItems = FindItemsByType(type, recurse);

			var groups = new List<List<Item>>();
			int idx = 0;

			while (idx < typedItems.Length)
			{
				Item a = typedItems[idx++];
				var group = new List<Item>();

				group.Add(a);

				while (idx < typedItems.Length)
				{
					Item b = typedItems[idx];
					int v = grouper(a, b);

					if (v == 0)
					{
						group.Add(b);
					}
					else
					{
						break;
					}

					++idx;
				}

				groups.Add(group);
			}</pre>

## Duplicated Code. Size: 244

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>int amount = item.Amount;
			m_Stream.Write((short)amount);
			m_Stream.Write((short)amount);

			Point3D loc = item.Location;
			int x = loc.m_X & 0x7FFF;
			int y = loc.m_Y & 0x3FFF;
			m_Stream.Write((short)x);
			m_Stream.Write((short)y);
			m_Stream.Write((sbyte)loc.m_Z);

			m_Stream.Write((byte)item.Light);
			m_Stream.Write((short)item.Hue);
			m_Stream.Write((byte)item.GetPacketFlags());</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>int amount = item.Amount;
            m_Stream.Write((short)amount);
            m_Stream.Write((short)amount);

            Point3D loc = item.Location;
            int x = loc.m_X & 0x7FFF;
            int y = loc.m_Y & 0x3FFF;
            m_Stream.Write((short)x);
            m_Stream.Write((short)y);
            m_Stream.Write((sbyte)loc.m_Z);

            m_Stream.Write((byte)item.Light);
            m_Stream.Write((short)item.Hue);
            m_Stream.Write((byte)item.GetPacketFlags());</pre>

## Duplicated Code. Size: 241

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.Map))
                        {
                            m_Map = reader.ReadMap();
                        }
                        else
                        {
                            m_Map = Map.Internal;
                        }

                        if (GetSaveFlag(flags, SaveFlag.Visible))
                        {
                            SetFlag(ImplFlag.Visible, reader.ReadBool());
                        }
                        else
                        {
                            SetFlag(ImplFlag.Visible, true);
                        }

                        if (GetSaveFlag(flags, SaveFlag.Movable))
                        {
                            SetFlag(ImplFlag.Movable, reader.ReadBool());
                        }
                        else
                        {
                            SetFlag(ImplFlag.Movable, true);
                        }

                        if (GetSaveFlag(flags, SaveFlag.Stackable))
                        {
                            SetFlag(ImplFlag.Stackable, reader.ReadBool());
                        }</pre>

Fragment 2 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.Map))
                        {
                            m_Map = reader.ReadMap();
                        }
                        else
                        {
                            m_Map = Map.Internal;
                        }

                        if (GetSaveFlag(flags, SaveFlag.Visible))
                        {
                            SetFlag(ImplFlag.Visible, reader.ReadBool());
                        }
                        else
                        {
                            SetFlag(ImplFlag.Visible, true);
                        }

                        if (GetSaveFlag(flags, SaveFlag.Movable))
                        {
                            SetFlag(ImplFlag.Movable, reader.ReadBool());
                        }
                        else
                        {
                            SetFlag(ImplFlag.Movable, true);
                        }

                        if (GetSaveFlag(flags, SaveFlag.Stackable))
                        {
                            SetFlag(ImplFlag.Stackable, reader.ReadBool());
                        }</pre>

## Duplicated Code. Size: 239

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>int hue = pvSrc.ReadUInt16();
			int hairVal = pvSrc.ReadInt16();
			int hairHue = pvSrc.ReadInt16();
			int hairValf = pvSrc.ReadInt16();
			int hairHuef = pvSrc.ReadInt16();
			pvSrc.ReadByte();
			int cityIndex = pvSrc.ReadByte();
			int charSlot = pvSrc.ReadInt32();
			int clientIP = pvSrc.ReadInt32();
			int shirtHue = pvSrc.ReadInt16();
			int pantsHue = pvSrc.ReadInt16();

			/*
			Pre-7.0.0.0:
			0x00, 0x01 -> Human Male, Human Female
			0x02, 0x03 -> Elf Male, Elf Female

			Post-7.0.0.0:
			0x00, 0x01
			0x02, 0x03 -> Human Male, Human Female
			0x04, 0x05 -> Elf Male, Elf Female
			0x05, 0x06 -> Gargoyle Male, Gargoyle Female
			*/

			bool female = ((genderRace % 2) != 0);

			Race race = null;</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>int hue = pvSrc.ReadUInt16();
			int hairVal = pvSrc.ReadInt16();
			int hairHue = pvSrc.ReadInt16();
			int hairValf = pvSrc.ReadInt16();
			int hairHuef = pvSrc.ReadInt16();
			pvSrc.ReadByte();
			int cityIndex = pvSrc.ReadByte();
			int charSlot = pvSrc.ReadInt32();
			int clientIP = pvSrc.ReadInt32();
			int shirtHue = pvSrc.ReadInt16();
			int pantsHue = pvSrc.ReadInt16();

			/*
			0x00, 0x01
			0x02, 0x03 -> Human Male, Human Female
			0x04, 0x05 -> Elf Male, Elf Female
			0x05, 0x06 -> Gargoyle Male, Gargoyle Female
			*/

			bool female = ((genderRace % 2) != 0);

			Race race = null;</pre>

## Duplicated Code. Size: 209

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>Point3D loc = m.Location;

			int hue = m.Hue;

			if (m.SolidHueOverride >= 0)
			{
				hue = m.SolidHueOverride;
			}

			m_Stream.Write(m.Serial);
			m_Stream.Write((short)m.Body);
			m_Stream.Write((short)loc.m_X);
			m_Stream.Write((short)loc.m_Y);
			m_Stream.Write((sbyte)loc.m_Z);
			m_Stream.Write((byte)m.Direction);
			m_Stream.Write((short)hue);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>Point3D loc = m.Location;

			int hue = m.Hue;

			if (m.SolidHueOverride >= 0)
			{
				hue = m.SolidHueOverride;
			}

			m_Stream.Write(m.Serial);
			m_Stream.Write((short)m.Body);
			m_Stream.Write((short)loc.m_X);
			m_Stream.Write((short)loc.m_Y);
			m_Stream.Write((sbyte)loc.m_Z);
			m_Stream.Write((byte)m.Direction);
			m_Stream.Write((short)hue);</pre>

## Duplicated Code. Size: 208

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>{
			int bound = m_Index + (fixedLength << 1);
			int end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			StringBuilder sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < bound && (c = (m_Data[m_Index++] | (m_Data[m_Index++] << 8))) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			m_Index = end;

			return sb.ToString();
		}</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>{
			int bound = m_Index + (fixedLength << 1);
			int end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			StringBuilder sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < bound && (c = ((m_Data[m_Index++] << 8) | m_Data[m_Index++])) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			m_Index = end;

			return sb.ToString();
		}</pre>

## Duplicated Code. Size: 207

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>public List<BaseModule> SearchModules(string search)
        {
            var keywords = search.ToLower().Split(' ');
            var modules = new List<BaseModule>();

            foreach (BaseModule mod in Modules)
            {
                bool match = true;
                string name = mod.Name.ToLower();

                foreach (string keyword in keywords)
                {
                    if (name.IndexOf(keyword, StringComparison.Ordinal) == -1)
                    {
                        match = false;
                    }
                }

                if (match)
                {
                    modules.Add(mod);
                }
            }

            return modules;
        }</pre>

Fragment 2 in file Server\Mobile.cs

<pre>public List<BaseModule> SearchModules(string search)
		{
			var keywords = search.ToLower().Split(' ');
			var modules = new List<BaseModule>();

			foreach (BaseModule mod in Modules)
			{
				bool match = true;
				string name = mod.Name.ToLower();

				foreach (string keyword in keywords)
				{
					if (name.IndexOf(keyword, StringComparison.Ordinal) == -1)
					{
						match = false;
					}
				}

				if (match)
				{
					modules.Add(mod);
				}
			}

			return modules;
		}</pre>

## Duplicated Code. Size: 206

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>if (s.IsMobile)
				{
					Mobile m = World.FindMobile(s);

					if (m != null && from.CanSee(m) && Utility.InUpdateRange(from, m))
					{
						m.SendPropertiesTo(from);
					}
				}
				else if (s.IsItem)
				{
					Item item = World.FindItem(s);

					if (item != null && !item.Deleted && from.CanSee(item) &&
						Utility.InUpdateRange(from.Location, item.GetWorldLocation()))
					{
						item.SendPropertiesTo(from);
					}
				}</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>if (s.IsMobile)
			{
				Mobile m = World.FindMobile(s);

				if (m != null && from.CanSee(m) && Utility.InUpdateRange(from, m))
				{
					m.SendPropertiesTo(from);
				}
			}
			else if (s.IsItem)
			{
				Item item = World.FindItem(s);

				if (item != null && !item.Deleted && from.CanSee(item) &&
					Utility.InUpdateRange(from.Location, item.GetWorldLocation()))
				{
					item.SendPropertiesTo(from);
				}
			}</pre>

## Duplicated Code. Size: 194

### Duplicated Fragments:

Fragment 1 in file Server\Random.cs

<pre>public unsafe double NextDouble()
		{
			var b = new byte[8];

			if (BitConverter.IsLittleEndian)
			{
				b[7] = 0;
				_GetBytes(b, 0, 7);
			}
			else
			{
				b[0] = 0;
				_GetBytes(b, 1, 7);
			}

			ulong r = 0;
			fixed (byte* buf = b)
			{
				r = *(ulong*)(&buf[0]) >> 3;
			}

			/* double: 53 bits of significand precision
			 * ulong.MaxValue >> 11 = 9007199254740991
			 * 2^53 = 9007199254740992
			 */

			return (double)r / 9007199254740992;
		}</pre>

Fragment 2 in file Server\Random.cs

<pre>public unsafe double NextDouble()
		{
			var b = new byte[8];

			if (BitConverter.IsLittleEndian)
			{
				b[7] = 0;
				_GetBytes(b, 0, 7);
			}
			else
			{
				b[0] = 0;
				_GetBytes(b, 1, 7);
			}

			ulong r = 0;
			fixed (byte* buf = b)
			{
				r = *(ulong*)(&buf[0]) >> 3;
			}

			/* double: 53 bits of significand precision
			 * ulong.MaxValue >> 11 = 9007199254740991
			 * 2^53 = 9007199254740992
			 */

			return (double)r / 9007199254740992;
		}</pre>

Fragment 3 in file Server\Random.cs

<pre>public unsafe double NextDouble()
		{
			var b = new byte[8];

			if (BitConverter.IsLittleEndian)
			{
				b[7] = 0;
				_GetBytes(b, 0, 7);
			}
			else
			{
				b[0] = 0;
				_GetBytes(b, 1, 7);
			}

			ulong r = 0;
			fixed (byte* buf = b)
			{
				r = *(ulong*)(&buf[0]) >> 3;
			}

			/* double: 53 bits of significand precision
			 * ulong.MaxValue >> 11 = 9007199254740991
			 * 2^53 = 9007199254740992
			 */

			return (double)r / 9007199254740992;
		}</pre>

## Duplicated Code. Size: 193

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>{
			m_Stream.Write(t.AllowGround);
			m_Stream.Write(t.TargetID);
			m_Stream.Write((byte)t.Flags);

			m_Stream.Fill();

			m_Stream.Seek(18, SeekOrigin.Begin);
			m_Stream.Write((short)t.MultiID);
			m_Stream.Write((short)t.Offset.X);
			m_Stream.Write((short)t.Offset.Y);
			m_Stream.Write((short)t.Offset.Z);
		}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>{
			m_Stream.Write(t.AllowGround);
			m_Stream.Write(t.TargetID);
			m_Stream.Write((byte)t.Flags);

			m_Stream.Fill();

			m_Stream.Seek(18, SeekOrigin.Begin);
			m_Stream.Write((short)t.MultiID);
			m_Stream.Write((short)t.Offset.X);
			m_Stream.Write((short)t.Offset.Y);
			m_Stream.Write((short)t.Offset.Z);
		}</pre>

## Duplicated Code. Size: 192

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>int checkTop = checkZ + id.CalcHeight;

                if (checkTop == checkZ && !id.Surface)
                {
                    ++checkTop;
                }

                int zStart = checkZ - z;
                int zEnd = checkTop - z;

                if (zStart >= 20 || zEnd < 0)
                {
                    continue;
                }

                if (zStart < 0)
                {
                    zStart = 0;
                }

                if (zEnd > 19)
                {
                    zEnd = 19;
                }

                int bitCount = zEnd - zStart;

                m_OpenSlots &= ~(((1 << bitCount) - 1) << zStart);</pre>

Fragment 2 in file Server\Item.cs

<pre>int checkTop = checkZ + id.CalcHeight;

                if (checkTop == checkZ && !id.Surface)
                {
                    ++checkTop;
                }

                int zStart = checkZ - z;
                int zEnd = checkTop - z;

                if (zStart >= 20 || zEnd < 0)
                {
                    continue;
                }

                if (zStart < 0)
                {
                    zStart = 0;
                }

                if (zEnd > 19)
                {
                    zEnd = 19;
                }

                int bitCount = zEnd - zStart;

                m_OpenSlots &= ~(((1 << bitCount) - 1) << zStart);</pre>

## Duplicated Code. Size: 190

### Duplicated Fragments:

Fragment 1 in file Server\Geometry.cs

<pre>int start = value.IndexOf('(');
			int end = value.IndexOf(',', start + 1);

			string param1 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			string param2 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;</pre>

Fragment 2 in file Server\Geometry.cs

<pre>int start = value.IndexOf('(');
			int end = value.IndexOf(',', start + 1);

			string param1 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;
			end = value.IndexOf(',', start + 1);

			string param2 = value.Substring(start + 1, end - (start + 1)).Trim();

			start = end;</pre>

## Duplicated Code. Size: 187

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteMobileList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((Mobile)list[i]).Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((Mobile)list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteMobileList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((Mobile)list[i]).Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((Mobile)list[i]);
			}
		}</pre>

## Duplicated Code. Size: 187

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteItemList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((Item)list[i]).Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((Item)list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteItemList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((Item)list[i]).Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((Item)list[i]);
			}
		}</pre>

## Duplicated Code. Size: 187

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteGuildList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((BaseGuild)list[i]).Disbanded)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((BaseGuild)list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteGuildList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((BaseGuild)list[i]).Disbanded)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((BaseGuild)list[i]);
			}
		}</pre>

## Duplicated Code. Size: 187

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteDataList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((SaveData)list[i]).Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((SaveData)list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteDataList(ArrayList list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (((SaveData)list[i]).Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write((BaseGuild)list[i]);
			}
		}</pre>

## Duplicated Code. Size: 184

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>switch (d & Direction.Mask)
					{
						case Direction.North:
							--y;
							break;
						case Direction.Right:
							++x;
							--y;
							break;
						case Direction.East:
							++x;
							break;
						case Direction.Down:
							++x;
							++y;
							break;
						case Direction.South:
							++y;
							break;
						case Direction.Left:
							--x;
							++y;
							break;
						case Direction.West:
							--x;
							break;
						case Direction.Up:
							--x;
							--y;
							break;
					}</pre>

Fragment 2 in file Server\Movement.cs

<pre>switch (d & Direction.Mask)
			{
				case Direction.North:
					--y;
					break;
				case Direction.South:
					++y;
					break;
				case Direction.West:
					--x;
					break;
				case Direction.East:
					++x;
					break;
				case Direction.Right:
					++x;
					--y;
					break;
				case Direction.Left:
					--x;
					++y;
					break;
				case Direction.Down:
					++x;
					++y;
					break;
				case Direction.Up:
					--x;
					--y;
					break;
			}</pre>

## Duplicated Code. Size: 183

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteItemList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteItemList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 183

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteMobileList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteMobileList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 183

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteGuildList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Disbanded)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteGuildList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Disbanded)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 183

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteDataList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteDataList<T>(List<T> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 182

### Duplicated Fragments:

Fragment 1 in file Server\ScriptCompiler.cs

<pre>CompilerParameters parms = new CompilerParameters(GetReferenceAssemblies(), path, debug);

				string options = GetCompilerOptions(debug);

				if (options != null)
				{
					parms.CompilerOptions = options;
				}

				if (Core.HaltOnWarning)
				{
					parms.WarningLevel = 4;
				}

#if !MONO
				CompilerResults results = provider.CompileAssemblyFromFile(parms, files);
#else
				parms.CompilerOptions = String.Format( "{0} /nowarn:169,219,414 /recurse:Scripts/*.cs", parms.CompilerOptions );
				CompilerResults results = provider.CompileAssemblyFromFile( parms, "" );
                #endif
				m_AdditionalReferences.Add(path);

				Display(results);

#if !MONO
				if (results.Errors.Count > 0)
				{
					assembly = null;
					return false;
				}</pre>

Fragment 2 in file Server\ScriptCompiler.cs

<pre>CompilerParameters parms = new CompilerParameters(GetReferenceAssemblies(), path, debug);

				string options = GetCompilerOptions(debug);

				if (options != null)
				{
					parms.CompilerOptions = options;
				}

				if (Core.HaltOnWarning)
				{
					parms.WarningLevel = 4;
				}

				CompilerResults results = provider.CompileAssemblyFromFile(parms, files);
				m_AdditionalReferences.Add(path);

				Display(results);

				if (results.Errors.Count > 0)
				{
					assembly = null;
					return false;
				}</pre>

## Duplicated Code. Size: 181

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>ns.Sequence = 0;
						ClearFastwalkStack();

						ns.Send(MobileIncoming.Create(ns, this, this));

						if (ns.StygianAbyss)
						{
							ns.Send(new MobileUpdate(this));
							CheckLightLevels(true);
							ns.Send(new MobileUpdate(this));
						}
						else
						{
							ns.Send(new MobileUpdateOld(this));
							CheckLightLevels(true);
							ns.Send(new MobileUpdateOld(this));
						}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>ns.Sequence = 0;
				ClearFastwalkStack();

				ns.Send(MobileIncoming.Create(ns, this, this));

				if (ns.StygianAbyss)
				{
					ns.Send(new MobileUpdate(this));
					CheckLightLevels(true);
					ns.Send(new MobileUpdate(this));
				}
				else
				{
					ns.Send(new MobileUpdateOld(this));
					CheckLightLevels(true);
					ns.Send(new MobileUpdateOld(this));
				}</pre>

## Duplicated Code. Size: 179

### Duplicated Fragments:

Fragment 1 in file Server\Persistence\DynamicSaveStrategy.cs

<pre>private void WriteCount(SequentialFileWriter indexFile, int count)
        {
            //Equiv to GenericWriter.Write( (int)count );
            byte[] buffer = new byte[4];

            buffer[0] = (byte)(count);
            buffer[1] = (byte)(count >> 8);
            buffer[2] = (byte)(count >> 16);
            buffer[3] = (byte)(count >> 24);

            indexFile.Write(buffer, 0, buffer.Length);
        }</pre>

Fragment 2 in file Server\Persistence\ParallelSaveStrategy.cs

<pre>private void WriteCount(SequentialFileWriter indexFile, int count)
        {
            byte[] buffer = new byte[4];

            buffer[0] = (byte)(count);
            buffer[1] = (byte)(count >> 8);
            buffer[2] = (byte)(count >> 16);
            buffer[3] = (byte)(count >> 24);

            indexFile.Write(buffer, 0, buffer.Length);
        }</pre>

## Duplicated Code. Size: 178

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>if (m_Index >= m_Size)
			{
				return String.Empty;
			}

			int count = 0;
			int index = m_Index;

			while (index < m_Size && m_Data[index++] != 0)
			{
				++count;
			}

			index = 0;

			var buffer = new byte[count];
			int value = 0;

			while (m_Index < m_Size && (value = m_Data[m_Index++]) != 0)
			{
				buffer[index++] = (byte)value;
			}</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>if (m_Index >= m_Size)
			{
				return String.Empty;
			}

			int count = 0;
			int index = m_Index;

			while (index < m_Size && m_Data[index++] != 0)
			{
				++count;
			}

			index = 0;

			var buffer = new byte[count];
			int value = 0;

			while (m_Index < m_Size && (value = m_Data[m_Index++]) != 0)
			{
				buffer[index++] = (byte)value;
			}</pre>

## Duplicated Code. Size: 178

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(List<Item> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(List<Item> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 178

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(List<Mobile> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(List<Mobile> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 178

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(List<BaseGuild> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Disbanded)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(List<BaseGuild> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Disbanded)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 178

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(List<SaveData> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(List<SaveData> list, bool tidy)
		{
			if (tidy)
			{
				for (int i = 0; i < list.Count;)
				{
					if (list[i].Deleted)
					{
						list.RemoveAt(i);
					}
					else
					{
						++i;
					}
				}
			}

			Write(list.Count);

			for (int i = 0; i < list.Count; ++i)
			{
				Write(list[i]);
			}
		}</pre>

## Duplicated Code. Size: 177

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>if (ns != null && m_Map != null)
					{
						ns.Sequence = 0;
						ns.Send(new MapChange(this));
						ns.Send(new MapPatches());
						ns.Send(SeasonChange.Instantiate(GetSeason(), true));

						if (ns.StygianAbyss)
						{
							ns.Send(new MobileUpdate(this));
						}
						else
						{
							ns.Send(new MobileUpdateOld(this));
						}

						ClearFastwalkStack();
					}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (ns != null && m_Map != null)
				{
					ns.Sequence = 0;
					ns.Send(new MapChange(this));
					ns.Send(new MapPatches());
					ns.Send(SeasonChange.Instantiate(GetSeason(), true));

					if (ns.StygianAbyss)
					{
						ns.Send(new MobileUpdate(this));
					}
					else
					{
						ns.Send(new MobileUpdateOld(this));
					}

					ClearFastwalkStack();
				}</pre>

## Duplicated Code. Size: 172

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new MobileStatus(m, m));
				state.Send(Network.SetWarMode.Instantiate(m.Warmode));

				m.SendEverything();

				state.Send(SupportedFeatures.Instantiate(state));
				state.Send(new MobileUpdate(m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Network.SetWarMode.Instantiate(m.Warmode));</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new MobileStatus(m, m));
				state.Send(Network.SetWarMode.Instantiate(m.Warmode));

				m.SendEverything();

				state.Send(SupportedFeatures.Instantiate(state));
				state.Send(new MobileUpdate(m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Network.SetWarMode.Instantiate(m.Warmode));</pre>

## Duplicated Code. Size: 172

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>for (int i = 0; i < a.Length; ++i)
				{
					Mobile check = a[i];

					if (check != null && check.Map != Map.Internal)
					{
						Utility.PushColor(ConsoleColor.Red);
						Console.WriteLine("Login: {0}: Account in use", state);
						Utility.PopColor();
						state.Send(new PopupMessage(PMMessage.CharInWorld));
						return;
					}
				}

				state.Flags = (ClientFlags)flags;</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>for (int i = 0; i < a.Length; ++i)
				{
					Mobile check = a[i];

					if (check != null && check.Map != Map.Internal)
					{
						Utility.PushColor(ConsoleColor.Red);
						Console.WriteLine("Login: {0}: Account in use", state);
						Utility.PopColor();
						state.Send(new PopupMessage(PMMessage.CharInWorld));
						return;
					}
				}

				state.Flags = (ClientFlags)flags;</pre>

## Duplicated Code. Size: 169

### Duplicated Fragments:

Fragment 1 in file Server\MultiData.cs

<pre>{
						var newTiles = new StaticTile[oldTiles.Length - 1];

						for (int j = 0; j < i; ++j)
						{
							newTiles[j] = oldTiles[j];
						}

						for (int j = i + 1; j < oldTiles.Length; ++j)
						{
							newTiles[j - 1] = oldTiles[j];
						}

						m_Tiles[vx][vy] = newTiles;

						break;
					}</pre>

Fragment 2 in file Server\MultiData.cs

<pre>{
						var newTiles = new StaticTile[oldTiles.Length - 1];

						for (int j = 0; j < i; ++j)
						{
							newTiles[j] = oldTiles[j];
						}

						for (int j = i + 1; j < oldTiles.Length; ++j)
						{
							newTiles[j - 1] = oldTiles[j];
						}

						m_Tiles[vx][vy] = newTiles;

						break;
					}</pre>

## Duplicated Code. Size: 165

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((0x7FFFFFFF - i));
					m_Stream.Write((ushort)0);
					m_Stream.Write((byte)0);
					m_Stream.Write((ushort)(i + offset));
					m_Stream.Write((short)0);
					m_Stream.Write((short)0);
					m_Stream.Write(item.Serial);
					m_Stream.Write((short)0);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((0x7FFFFFFF - i));
					m_Stream.Write((ushort)0);
					m_Stream.Write((byte)0);
					m_Stream.Write((ushort)(i + offset));
					m_Stream.Write((short)0);
					m_Stream.Write((short)0);
					m_Stream.Write((byte)0); // Grid Location?
					m_Stream.Write(item.Serial);</pre>

## Duplicated Code. Size: 162

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>EnsureCapacity(256);

			m_Stream.Write(((IMenu)menu).Serial);
			m_Stream.Write((short)0);

			string question = menu.Question;

			if (question == null)
			{
				m_Stream.Write((byte)0);
			}
			else
			{
				int questionLength = question.Length;
				m_Stream.Write((byte)questionLength);
				m_Stream.WriteAsciiFixed(question, questionLength);
			}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>EnsureCapacity(256);

			m_Stream.Write(((IMenu)menu).Serial);
			m_Stream.Write((short)0);

			string question = menu.Question;

			if (question == null)
			{
				m_Stream.Write((byte)0);
			}
			else
			{
				int questionLength = question.Length;
				m_Stream.Write((byte)questionLength);
				m_Stream.WriteAsciiFixed(question, questionLength);
			}</pre>

## Duplicated Code. Size: 159

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>{
			if ((m_Index + 4) > m_Buffer.Length)
			{
				Flush();
			}

			m_Buffer[m_Index] = (byte)value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Index += 4;
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>{
			if ((m_Index + 4) > m_Buffer.Length)
			{
				Flush();
			}

			m_Buffer[m_Index] = (byte)value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Buffer[m_Index + 2] = (byte)(value >> 16);
			m_Buffer[m_Index + 3] = (byte)(value >> 24);
			m_Index += 4;
		}</pre>

## Duplicated Code. Size: 155

### Duplicated Fragments:

Fragment 1 in file Server\MultiData.cs

<pre>{
						var newList = new MultiTileEntry[oldList.Length - 1];

						for (int j = 0; j < i; ++j)
						{
							newList[j] = oldList[j];
						}

						for (int j = i + 1; j < oldList.Length; ++j)
						{
							newList[j - 1] = oldList[j];
						}

						m_List = newList;

						break;
					}</pre>

Fragment 2 in file Server\MultiData.cs

<pre>{
						var newList = new MultiTileEntry[oldList.Length - 1];

						for (int j = 0; j < i; ++j)
						{
							newList[j] = oldList[j];
						}

						for (int j = i + 1; j < oldList.Length; ++j)
						{
							newList[j - 1] = oldList[j];
						}

						m_List = newList;

						break;
					}</pre>

## Duplicated Code. Size: 150

### Duplicated Fragments:

Fragment 1 in file Server\Utility.cs

<pre>{
					int c = input.ReadByte();

					bytes.Append(c.ToString("X2"));

					if (j != 7)
					{
						bytes.Append(' ');
					}
					else
					{
						bytes.Append("  ");
					}

					if (c >= 0x20 && c < 0x80)
					{
						chars.Append((char)c);
					}
					else
					{
						chars.Append('.');
					}
				}</pre>

Fragment 2 in file Server\Utility.cs

<pre>{
						int c = input.ReadByte();

						bytes.Append(c.ToString("X2"));

						if (j != 7)
						{
							bytes.Append(' ');
						}
						else
						{
							bytes.Append("  ");
						}

						if (c >= 0x20 && c < 0x80)
						{
							chars.Append((char)c);
						}
						else
						{
							chars.Append('.');
						}
					}</pre>

## Duplicated Code. Size: 149

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.IntWeight))
                            {
                                weight = reader.ReadEncodedInt();
                            }
                            else if (GetSaveFlag(flags, SaveFlag.WeightNot1or0))
                            {
                                weight = reader.ReadDouble();
                            }
                            else if (GetSaveFlag(flags, SaveFlag.WeightIs0))
                            {
                                weight = 0.0;
                            }
                            else
                            {
                                weight = 1.0;
                            }

                            if (weight != DefaultWeight)
                            {
                                AcquireCompactInfo().m_Weight = weight;
                            }</pre>

Fragment 2 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.IntWeight))
                        {
                            weight = reader.ReadEncodedInt();
                        }
                        else if (GetSaveFlag(flags, SaveFlag.WeightNot1or0))
                        {
                            weight = reader.ReadDouble();
                        }
                        else if (GetSaveFlag(flags, SaveFlag.WeightIs0))
                        {
                            weight = 0.0;
                        }
                        else
                        {
                            weight = 1.0;
                        }

                        if (weight != DefaultWeight)
                        {
                            AcquireCompactInfo().m_Weight = weight;
                        }</pre>

## Duplicated Code. Size: 149

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>BuyItemState bis = list[i];

				m_Stream.Write(bis.MySerial);
				m_Stream.Write((ushort)bis.ItemID);
				m_Stream.Write((byte)0); //itemid offset
				m_Stream.Write((ushort)bis.Amount);
				m_Stream.Write((short)(i + 1)); //x
				m_Stream.Write((short)1); //y</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>BuyItemState bis = list[i];

				m_Stream.Write(bis.MySerial);
				m_Stream.Write((ushort)bis.ItemID);
				m_Stream.Write((byte)0); //itemid offset
				m_Stream.Write((ushort)bis.Amount);
				m_Stream.Write((short)(i + 1)); //x
				m_Stream.Write((short)1); //y</pre>

## Duplicated Code. Size: 148

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (!item.IsVirtualItem)
                {
                    UpdateTotal(item, TotalType.Gold, -item.TotalGold);
                    UpdateTotal(item, TotalType.Items, -(item.TotalItems + 1));
                    UpdateTotal(item, TotalType.Weight, -(item.TotalWeight + item.PileWeight));
                }

                item.Parent = null;

                item.OnRemoved(this);
                OnItemRemoved(item);</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (!item.IsVirtualItem)
				{
					UpdateTotal(item, TotalType.Gold, -item.TotalGold);
					UpdateTotal(item, TotalType.Items, -(item.TotalItems + 1));
					UpdateTotal(item, TotalType.Weight, -(item.TotalWeight + item.PileWeight));
				}

				item.Parent = null;

				item.OnRemoved(this);
				OnItemRemoved(item);</pre>

## Duplicated Code. Size: 145

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new ClientVersionReq());

				state.BlockAllPackets = true;

				EventSink.InvokeCharacterCreated(args);

				Mobile m = args.Mobile;

				if (m != null)
				{
					state.Mobile = m;
					m.NetState = state;
					new LoginTimer(state, m).Start();
				}
				else
				{
					state.BlockAllPackets = false;
					state.Dispose();
				}</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new ClientVersionReq());

				state.BlockAllPackets = true;

				EventSink.InvokeCharacterCreated(args);

				Mobile m = args.Mobile;

				if (m != null)
				{
					state.Mobile = m;
					m.NetState = state;
					new LoginTimer(state, m).Start();
				}
				else
				{
					state.BlockAllPackets = false;
					state.Dispose();
				}</pre>

## Duplicated Code. Size: 144

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>{
			StringBuilder sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = (m_Data[m_Index++] | (m_Data[m_Index++] << 8))) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			return sb.ToString();
		}</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>{
			StringBuilder sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = ((m_Data[m_Index++] << 8) | m_Data[m_Index++])) != 0)
			{
				if (IsSafeChar(c))
				{
					sb.Append((char)c);
				}
			}

			return sb.ToString();
		}</pre>

## Duplicated Code. Size: 142

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (!item.IsVirtualItem)
            {
                UpdateTotal(item, TotalType.Gold, item.TotalGold);
                UpdateTotal(item, TotalType.Items, item.TotalItems + 1);
                UpdateTotal(item, TotalType.Weight, item.TotalWeight + item.PileWeight);
            }

            item.Delta(ItemDelta.Update);

            item.OnAdded(this);
            OnItemAdded(item);</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (!item.IsVirtualItem)
			{
				UpdateTotal(item, TotalType.Gold, item.TotalGold);
				UpdateTotal(item, TotalType.Items, item.TotalItems + 1);
				UpdateTotal(item, TotalType.Weight, item.TotalWeight + item.PileWeight);
			}

			item.Delta(ItemDelta.Update);

			item.OnAdded(this);
			OnItemAdded(item);</pre>

## Duplicated Code. Size: 141

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteDeltaTime(DateTime value)
		{
			long ticks = value.Ticks;
			long now = DateTime.UtcNow.Ticks;

			TimeSpan d;

			try
			{
				d = new TimeSpan(ticks - now);
			}
			catch
			{
				if (ticks < now)
				{
					d = TimeSpan.MaxValue;
				}
				else
				{
					d = TimeSpan.MaxValue;
				}
			}

			Write(d);
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteDeltaTime(DateTime value)
		{
			long ticks = value.Ticks;
			long now = DateTime.UtcNow.Ticks;

			TimeSpan d;

			try
			{
				d = new TimeSpan(ticks - now);
			}
			catch
			{
				if (ticks < now)
				{
					d = TimeSpan.MaxValue;
				}
				else
				{
					d = TimeSpan.MaxValue;
				}
			}

			Write(d);
		}</pre>

## Duplicated Code. Size: 137

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\GumpButton.cs

<pre>public override void AppendTo( IGumpWriter disp )
		{
			disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_ID1 );
			disp.AppendLayout( m_ID2 );
			disp.AppendLayout( (int)m_Type );
			disp.AppendLayout( m_Param );
			disp.AppendLayout( m_ButtonID );
		}</pre>

Fragment 2 in file Server\Gumps\KRGumpButton.cs

<pre>public override void AppendTo( IGumpWriter disp )
		{
			disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_ID1 );
			disp.AppendLayout( m_ID2 );
			disp.AppendLayout( (int) m_Type );
			disp.AppendLayout( m_Param );
			disp.AppendLayout( m_ButtonID );
		}</pre>

## Duplicated Code. Size: 136

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.Direction))
                        {
                            m_Direction = (Direction)reader.ReadByte();
                        }

                        if (GetSaveFlag(flags, SaveFlag.Bounce))
                        {
                            AcquireCompactInfo().m_Bounce = BounceInfo.Deserialize(reader);
                        }

                        if (GetSaveFlag(flags, SaveFlag.LootType))
                        {
                            m_LootType = (LootType)reader.ReadByte();
                        }</pre>

Fragment 2 in file Server\Item.cs

<pre>if (GetSaveFlag(flags, SaveFlag.Direction))
                        {
                            m_Direction = (Direction)reader.ReadByte();
                        }

                        if (GetSaveFlag(flags, SaveFlag.Bounce))
                        {
                            AcquireCompactInfo().m_Bounce = BounceInfo.Deserialize(reader);
                        }

                        if (GetSaveFlag(flags, SaveFlag.LootType))
                        {
                            m_LootType = (LootType)reader.ReadByte();
                        }</pre>

## Duplicated Code. Size: 136

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>if (Core.HS && ns != null && ns.ExtendedStatus)
			{
				type = 6;
				EnsureCapacity(121);
			}
			else if (Core.ML && ns != null && ns.SupportsExpansion(Expansion.ML))
			{
				type = 5;
				EnsureCapacity(91);
			}
			else
			{
				type = Core.AOS ? 4 : 3;
				EnsureCapacity(88);
			}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>if (Core.HS && ns != null && ns.ExtendedStatus)
            {
                type = 6;
                EnsureCapacity(121);
            }
            else if (Core.ML && ns != null && ns.SupportsExpansion(Expansion.ML))
            {
                type = 5;
                EnsureCapacity(91);
            }
            else
            {
                type = Core.AOS ? 4 : 3;
                EnsureCapacity(88);
            }</pre>

## Duplicated Code. Size: 132

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\GumpHtmlLocalized.cs

<pre>{
					disp.AppendLayout( m_LayoutNameColor );

					disp.AppendLayout( m_X );
					disp.AppendLayout( m_Y );
					disp.AppendLayout( m_Width );
					disp.AppendLayout( m_Height );
					disp.AppendLayout( m_Number );
					disp.AppendLayout( m_Background );
					disp.AppendLayout( m_Scrollbar );
					disp.AppendLayout( m_Color );

					break;
				}</pre>

Fragment 2 in file Server\Gumps\KRGumpHtmlLocalized.cs

<pre>{
						disp.AppendLayout( m_LayoutNameColor );
						disp.AppendLayout( m_X );
						disp.AppendLayout( m_Y );
						disp.AppendLayout( m_Width );
						disp.AppendLayout( m_Height );
						disp.AppendLayout( m_Number );
						disp.AppendLayout( m_Background );
						disp.AppendLayout( m_Scrollbar );
						disp.AppendLayout( m_Color );

						break;
					}</pre>

## Duplicated Code. Size: 132

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>string type;

				if (guild.Type >= 0 && (int)guild.Type < m_GuildTypes.Length)
				{
					type = m_GuildTypes[(int)guild.Type];
				}
				else
				{
					type = "";
				}

				string title = GuildTitle;

				if (title == null)
				{
					title = "";
				}
				else
				{
					title = title.Trim();
				}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>string title = GuildTitle;
					string type;

					if (title == null)
					{
						title = "";
					}
					else
					{
						title = title.Trim();
					}

					if (guild.Type >= 0 && (int)guild.Type < m_GuildTypes.Length)
					{
						type = m_GuildTypes[(int)guild.Type];
					}
					else
					{
						type = "";
					}</pre>

## Duplicated Code. Size: 132

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write(beheld.Serial);
			m_Stream.Write((short)beheld.Body);
			m_Stream.Write((short)beheld.X);
			m_Stream.Write((short)beheld.Y);
			m_Stream.Write((sbyte)beheld.Z);
			m_Stream.Write((byte)beheld.Direction);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write(beheld.Serial);
			m_Stream.Write((short)beheld.Body);
			m_Stream.Write((short)beheld.X);
			m_Stream.Write((short)beheld.Y);
			m_Stream.Write((sbyte)beheld.Z);
			m_Stream.Write((byte)beheld.Direction);</pre>

## Duplicated Code. Size: 130

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketWriter.cs

<pre>{
			m_Buffer[0] = (byte)(value >> 24);
			m_Buffer[1] = (byte)(value >> 16);
			m_Buffer[2] = (byte)(value >> 8);
			m_Buffer[3] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 4);
		}</pre>

Fragment 2 in file Server\Network\PacketWriter.cs

<pre>{
			m_Buffer[0] = (byte)(value >> 24);
			m_Buffer[1] = (byte)(value >> 16);
			m_Buffer[2] = (byte)(value >> 8);
			m_Buffer[3] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 4);
		}</pre>

## Duplicated Code. Size: 129

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)0);
			m_Stream.Write((short)item.Amount);
			m_Stream.Write((short)item.X);
			m_Stream.Write((short)item.Y);
			m_Stream.Write(m.Serial);
			m_Stream.Write((short)item.Hue);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)item.Amount);
			m_Stream.Write((short)item.X);
			m_Stream.Write((short)item.Y);
			m_Stream.Write((byte)0); // Grid Location?
			m_Stream.Write(m.Serial);
			m_Stream.Write((short)item.Hue);</pre>

## Duplicated Code. Size: 128

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>{
			StringBuilder sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = (m_Data[m_Index++] | (m_Data[m_Index++] << 8))) != 0)
			{
				sb.Append((char)c);
			}

			return sb.ToString();
		}</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>{
			StringBuilder sb = new StringBuilder();

			int c;

			while ((m_Index + 1) < m_Size && (c = ((m_Data[m_Index++] << 8) | m_Data[m_Index++])) != 0)
			{
				sb.Append((char)c);
			}

			return sb.ToString();
		}</pre>

## Duplicated Code. Size: 128

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>if (isSafe)
			{
				return s;
			}

			StringBuilder sb = new StringBuilder(s.Length);

			for (int i = 0; i < s.Length; ++i)
			{
				if (IsSafeChar(s[i]))
				{
					sb.Append(s[i]);
				}
			}

			return sb.ToString();</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>if (isSafe)
			{
				return s;
			}

			StringBuilder sb = new StringBuilder(s.Length);

			for (int i = 0; i < s.Length; ++i)
			{
				if (IsSafeChar(s[i]))
				{
					sb.Append(s[i]);
				}
			}

			return sb.ToString();</pre>

## Duplicated Code. Size: 128

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write(renderMode);
			m_Stream.Write((short)effect);
			m_Stream.Write((short)explodeEffect);
			m_Stream.Write((short)explodeSound);
			m_Stream.Write(serial);
			m_Stream.Write((byte)layer);
			m_Stream.Write((short)unknown);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write(renderMode);
			m_Stream.Write((short)effect);
			m_Stream.Write((short)explodeEffect);
			m_Stream.Write((short)explodeSound);
			m_Stream.Write(serial);
			m_Stream.Write((byte)layer);
			m_Stream.Write((short)unknown);</pre>

## Duplicated Code. Size: 127

### Duplicated Fragments:

Fragment 1 in file Server\Persistence\DynamicSaveStrategy.cs

<pre>private void SaveTypeDatabase(string path, List<Type> types)
        {
            BinaryFileWriter bfw = new BinaryFileWriter(path, false);

            bfw.Write(types.Count);

            foreach (Type type in types)
            {
                bfw.Write(type.FullName);
            }

            bfw.Flush();

            bfw.Close();
        }</pre>

Fragment 2 in file Server\Persistence\ParallelSaveStrategy.cs

<pre>private void SaveTypeDatabase(string path, List<Type> types)
        {
            BinaryFileWriter bfw = new BinaryFileWriter(path, false);

            bfw.Write(types.Count);

            foreach (Type type in types)
            {
                bfw.Write(type.FullName);
            }

            bfw.Flush();

            bfw.Close();
        }</pre>

## Duplicated Code. Size: 126

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\GumpCheck.cs

<pre>public override void AppendTo( IGumpWriter disp )
		{
			disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_ID1 );
			disp.AppendLayout( m_ID2 );
			disp.AppendLayout( m_InitialState );
			disp.AppendLayout( m_SwitchID );

			disp.Switches++;
		}</pre>

Fragment 2 in file Server\Gumps\GumpRadio.cs

<pre>public override void AppendTo( IGumpWriter disp )
		{
			disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_ID1 );
			disp.AppendLayout( m_ID2 );
			disp.AppendLayout( m_InitialState );
			disp.AppendLayout( m_SwitchID );

			disp.Switches++;
		}</pre>

## Duplicated Code. Size: 125

### Duplicated Fragments:

Fragment 1 in file Server\World.cs

<pre>BaseModule module = data as BaseModule;

					bool match = true;
					string name = module.Name.ToLower();

					for (int i = 0; i < keywords.Length; i++)
					{
						if (name.IndexOf(keywords[i]) == -1)
						{
							match = false;
						}
					}</pre>

Fragment 2 in file Server\World.cs

<pre>BaseModule module = data as BaseModule;

					bool match = true;
					string name = module.Name.ToLower();

					for (int i = 0; i < keywords.Length; i++)
					{
						if (name.IndexOf(keywords[i]) == -1)
						{
							match = false;
						}
					}</pre>

## Duplicated Code. Size: 122

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>int hue = m.Hue;

			if (m.SolidHueOverride >= 0)
			{
				hue = m.SolidHueOverride;
			}

			m_Stream.Write(m.Serial);
			m_Stream.Write((short)m.Body);
			m_Stream.Write((byte)0);
			m_Stream.Write((short)hue);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>int hue = m.Hue;

			if (m.SolidHueOverride >= 0)
			{
				hue = m.SolidHueOverride;
			}

			m_Stream.Write(m.Serial);
			m_Stream.Write((short)m.Body);
			m_Stream.Write((byte)0);
			m_Stream.Write((short)hue);</pre>

## Duplicated Code. Size: 121

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>Mobile from = this;
			Item item = from.Holding;

			bool valid = (item != null && item.HeldBy == from && item.Map == Map.Internal);

			from.Holding = null;

			if (!valid)
			{
				return false;
			}

			bool bounced = true;

			item.SetLastMoved();</pre>

Fragment 2 in file Server\Mobile.cs

<pre>Mobile from = this;
			Item item = from.Holding;

			bool valid = (item != null && item.HeldBy == from && item.Map == Map.Internal);

			from.Holding = null;

			if (!valid)
			{
				return false;
			}

			bool bounced = true;

			item.SetLastMoved();</pre>

Fragment 3 in file Server\Mobile.cs

<pre>Mobile from = this;
			Item item = from.Holding;

			bool valid = (item != null && item.HeldBy == from && item.Map == Map.Internal);

			from.Holding = null;

			if (!valid)
			{
				return false;
			}

			bool bounced = true;

			item.SetLastMoved();</pre>

## Duplicated Code. Size: 121

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>var eable = m_Map.GetClientsInRange(m_Location);

				foreach (NetState state in eable)
				{
					if (state.Mobile.CanSee(this) && (noLineOfSight || state.Mobile.InLOS(this)))
					{
						state.Send(p);
					}
				}

				Packet.Release(p);

				eable.Free();</pre>

Fragment 2 in file Server\Mobile.cs

<pre>var eable = m_Map.GetClientsInRange(m_Location);

				foreach (NetState state in eable)
				{
					if (state.Mobile.CanSee(this) && (noLineOfSight || state.Mobile.InLOS(this)))
					{
						state.Send(p);
					}
				}

				Packet.Release(p);

				eable.Free();</pre>

Fragment 3 in file Server\Mobile.cs

<pre>var eable = m_Map.GetClientsInRange(m_Location);

				foreach (NetState state in eable)
				{
					if (state.Mobile.CanSee(this) && (noLineOfSight || state.Mobile.InLOS(this)))
					{
						state.Send(p);
					}
				}

				Packet.Release(p);

				eable.Free();</pre>

## Duplicated Code. Size: 118

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\GumpHtmlLocalized.cs

<pre>{
					disp.AppendLayout( m_LayoutNamePlain );

					disp.AppendLayout( m_X );
					disp.AppendLayout( m_Y );
					disp.AppendLayout( m_Width );
					disp.AppendLayout( m_Height );
					disp.AppendLayout( m_Number );
					disp.AppendLayout( m_Background );
					disp.AppendLayout( m_Scrollbar );

					break;
				}</pre>

Fragment 2 in file Server\Gumps\KRGumpHtmlLocalized.cs

<pre>{
						disp.AppendLayout( m_LayoutNamePlain );
						disp.AppendLayout( m_X );
						disp.AppendLayout( m_Y );
						disp.AppendLayout( m_Width );
						disp.AppendLayout( m_Height );
						disp.AppendLayout( m_Number );
						disp.AppendLayout( m_Background );
						disp.AppendLayout( m_Scrollbar );

						break;
					}</pre>

## Duplicated Code. Size: 118

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>{
			if (m_Enabled && max != 0)
			{
				stream.Write((short)m_Maximum);
				stream.Write((short)((cur * m_Maximum) / max));
			}
			else
			{
				stream.Write((short)max);
				stream.Write((short)cur);
			}
		}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>{
			if (m_Enabled && max != 0)
			{
				stream.Write((short)((cur * m_Maximum) / max));
				stream.Write((short)m_Maximum);
			}
			else
			{
				stream.Write((short)cur);
				stream.Write((short)max);
			}
		}</pre>

## Duplicated Code. Size: 117

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>Type ourType = GetType();
			m_TypeRef = World.m_MobileTypes.IndexOf(ourType);

			if (m_TypeRef == -1)
			{
				World.m_MobileTypes.Add(ourType);
				m_TypeRef = World.m_MobileTypes.Count - 1;
			}

			Timer.DelayCall(EventSink.InvokeMobileCreated, new MobileCreatedEventArgs(this));</pre>

Fragment 2 in file Server\Mobile.cs

<pre>Type ourType = GetType();
			m_TypeRef = World.m_MobileTypes.IndexOf(ourType);

			if (m_TypeRef == -1)
			{
				World.m_MobileTypes.Add(ourType);
				m_TypeRef = World.m_MobileTypes.Count - 1;
			}

			Timer.DelayCall(EventSink.InvokeMobileCreated, new MobileCreatedEventArgs(this));</pre>

## Duplicated Code. Size: 115

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (parent.KeepsItemsOnDeath)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else if (CheckBlessed(parent))
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else if (CheckNewbied() && parent.Kills < 5)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else if (parent.Player && Nontransferable)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else
            {
                return DeathMoveResult.MoveToCorpse;
            }</pre>

Fragment 2 in file Server\Item.cs

<pre>if (parent.KeepsItemsOnDeath)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else if (CheckBlessed(parent))
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else if (CheckNewbied() && parent.Kills < 5)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else if (parent.Player && Nontransferable)
            {
                return DeathMoveResult.MoveToBackpack;
            }
            else
            {
                return DeathMoveResult.MoveToCorpse;
            }</pre>

## Duplicated Code. Size: 115

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>CharacterListFlags flags = ExpansionInfo.CoreExpansion.CharacterListFlags;

			if (count > 6)
			{
				flags |= (CharacterListFlags.SeventhCharacterSlot | CharacterListFlags.SixthCharacterSlot);
			}
				// 7th Character Slot - TODO: Is SixthCharacterSlot Required?
			else if (count == 6)
			{
				flags |= CharacterListFlags.SixthCharacterSlot; // 6th Character Slot
			}
			else if (a.Limit == 1)
			{
				flags |= (CharacterListFlags.SlotLimit & CharacterListFlags.OneCharacterSlot); // Limit Characters & One Character
			}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>CharacterListFlags flags = ExpansionInfo.CoreExpansion.CharacterListFlags;

			if (count > 6)
			{
				flags |= (CharacterListFlags.SeventhCharacterSlot | CharacterListFlags.SixthCharacterSlot);
			}
				// 7th Character Slot - TODO: Is SixthCharacterSlot Required?
			else if (count == 6)
			{
				flags |= CharacterListFlags.SixthCharacterSlot; // 6th Character Slot
			}
			else if (a.Limit == 1)
			{
				flags |= (CharacterListFlags.SlotLimit & CharacterListFlags.OneCharacterSlot); // Limit Characters & One Character
			}</pre>

## Duplicated Code. Size: 112

### Duplicated Fragments:

Fragment 1 in file Server\ScriptCompiler.cs

<pre>string fileName = kvp.Key;
					var list = kvp.Value;

					string fullPath = Path.GetFullPath(fileName);
					string usedPath = Uri.UnescapeDataString(scriptRootUri.MakeRelativeUri(new Uri(fullPath)).OriginalString);

					Console.WriteLine(" + {0}:", usedPath);</pre>

Fragment 2 in file Server\ScriptCompiler.cs

<pre>string fileName = kvp.Key;
					var list = kvp.Value;

					string fullPath = Path.GetFullPath(fileName);
					string usedPath = Uri.UnescapeDataString(scriptRootUri.MakeRelativeUri(new Uri(fullPath)).OriginalString);

					Console.WriteLine(" + {0}:", usedPath);</pre>

## Duplicated Code. Size: 112

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)m.X);
			m_Stream.Write((short)m.Y);
			m_Stream.Write((short)0);
			m_Stream.Write((byte)m.Direction);
			m_Stream.Write((sbyte)m.Z);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)m.X);
			m_Stream.Write((short)m.Y);
			m_Stream.Write((short)0);
			m_Stream.Write((byte)m.Direction);
			m_Stream.Write((sbyte)m.Z);</pre>

Fragment 3 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)m.X);
			m_Stream.Write((short)m.Y);
			m_Stream.Write((short)m.Z);
			m_Stream.Write((byte)m.Direction);
			m_Stream.Write((byte)0);</pre>

## Duplicated Code. Size: 111

### Duplicated Fragments:

Fragment 1 in file Server\Point3DList.cs

<pre>if ((m_Count + 1) > m_List.Length)
			{
				var old = m_List;
				m_List = new Point3D[old.Length * 2];

				for (int i = 0; i < old.Length; ++i)
				{
					m_List[i] = old[i];
				}
			}</pre>

Fragment 2 in file Server\Point3DList.cs

<pre>if ((m_Count + 1) > m_List.Length)
			{
				var old = m_List;
				m_List = new Point3D[old.Length * 2];

				for (int i = 0; i < old.Length; ++i)
				{
					m_List[i] = old[i];
				}
			}</pre>

## Duplicated Code. Size: 110

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)i);

				int range = e.Range;

				if (range == -1)
				{
					range = 18;
				}

				CMEFlags flags = (e.Enabled && menu.From.InRange(p, range)) ? CMEFlags.None : CMEFlags.Disabled;</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)i);

                int range = e.Range;

				if (range == -1)
				{
					range = 18;
				}

				CMEFlags flags = (e.Enabled && menu.From.InRange(p, range)) ? CMEFlags.None : CMEFlags.Disabled;</pre>

## Duplicated Code. Size: 109

### Duplicated Fragments:

Fragment 1 in file Server\World.cs

<pre>int typeID = idxReader.ReadInt32();
							int serial = idxReader.ReadInt32();
							long pos = idxReader.ReadInt64();
							int length = idxReader.ReadInt32();

							var objs = types[typeID];

							if (objs == null)
							{
								continue;
							}</pre>

Fragment 2 in file Server\World.cs

<pre>int typeID = idxReader.ReadInt32();
							int serial = idxReader.ReadInt32();
							long pos = idxReader.ReadInt64();
							int length = idxReader.ReadInt32();

							var objs = types[typeID];

							if (objs == null)
							{
								continue;
							}</pre>

## Duplicated Code. Size: 108

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteItemSet<T>(HashSet<T> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(item => item.Deleted);
			}

			Write(set.Count);

			foreach (Item item in set)
			{
				Write(item);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteItemSet<T>(HashSet<T> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(item => item.Deleted);
			}

			Write(set.Count);

			foreach (Item item in set)
			{
				Write(item);
			}
		}</pre>

## Duplicated Code. Size: 108

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteMobileSet<T>(HashSet<T> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(mob => mob.Deleted);
			}

			Write(set.Count);

			foreach (Mobile mob in set)
			{
				Write(mob);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteMobileSet<T>(HashSet<T> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(mob => mob.Deleted);
			}

			Write(set.Count);

			foreach (Mobile mob in set)
			{
				Write(mob);
			}
		}</pre>

## Duplicated Code. Size: 108

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void WriteGuildSet<T>(HashSet<T> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(guild => guild.Disbanded);
			}

			Write(set.Count);

			foreach (BaseGuild guild in set)
			{
				Write(guild);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void WriteGuildSet<T>(HashSet<T> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(guild => guild.Disbanded);
			}

			Write(set.Count);

			foreach (BaseGuild guild in set)
			{
				Write(guild);
			}
		}</pre>

## Duplicated Code. Size: 107

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new MobileUpdateOld(m));

				state.Send(new MobileIncomingOld(m, m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Network.SetWarMode.Instantiate(m.Warmode));</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new MobileUpdateOld(m));
				//state.Send( new MobileAttributes( m ) );
				state.Send(new MobileStatus(m, m));
				state.Send(Network.SetWarMode.Instantiate(m.Warmode));
				state.Send(new MobileIncomingOld(m, m));</pre>

## Duplicated Code. Size: 105

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>var eable = m_Map.GetClientsInRange(m_Location);

				foreach (NetState state in eable)
				{
					if (state != m_NetState && state.Mobile.CanSee(this))
					{
						state.Send(p);
					}
				}

				Packet.Release(p);

				eable.Free();</pre>

Fragment 2 in file Server\Mobile.cs

<pre>var eable = m_Map.GetClientsInRange(m_Location);

				foreach (NetState state in eable)
				{
					if (state != m_NetState && state.Mobile.CanSee(this))
					{
						state.Send(p);
					}
				}

				Packet.Release(p);

				eable.Free();</pre>

## Duplicated Code. Size: 105

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>new SkillNameValue[4]
					{
						new SkillNameValue((SkillName)is1, vs1), new SkillNameValue((SkillName)is2, vs2),
						new SkillNameValue((SkillName)is3, vs3), new SkillNameValue((SkillName)is4, vs4),
					}</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>new SkillNameValue[4]
                    {
                        new SkillNameValue( (SkillName)is1, vs1 ),
                        new SkillNameValue( (SkillName)is2, vs2 ),
                        new SkillNameValue( (SkillName)is3, vs3 ),
                        new SkillNameValue( (SkillName)is4, vs4 ),
                    }</pre>

## Duplicated Code. Size: 105

### Duplicated Fragments:

Fragment 1 in file Server\World.cs

<pre>if (!Directory.Exists("Saves/Mobiles/"))
			{
				Directory.CreateDirectory("Saves/Mobiles/");
			}

			if (!Directory.Exists("Saves/Items/"))
			{
				Directory.CreateDirectory("Saves/Items/");
			}

			if (!Directory.Exists("Saves/Guilds/"))
			{
				Directory.CreateDirectory("Saves/Guilds/");
			}</pre>

Fragment 2 in file Server\World.cs

<pre>if (!Directory.Exists("Saves/Mobiles/"))
			{
				Directory.CreateDirectory("Saves/Mobiles/");
			}
			if (!Directory.Exists("Saves/Items/"))
			{
				Directory.CreateDirectory("Saves/Items/");
			}
			if (!Directory.Exists("Saves/Guilds/"))
			{
				Directory.CreateDirectory("Saves/Guilds/");
			}</pre>

## Duplicated Code. Size: 104

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>for (int i = 0; i < cache.Length; ++i)
				{
					for (int j = 0; j < cache[i].Length; ++j)
					{
						Packet.Release(ref cache[i][j]);
					}
				}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>for (int i = 0; i < cache.Length; ++i)
				{
					for (int j = 0; j < cache[i].Length; ++j)
					{
						Packet.Release(ref cache[i][j]);
					}
				}</pre>

## Duplicated Code. Size: 104

### Duplicated Fragments:

Fragment 1 in file Server\Random.cs

<pre>private void CheckSwap(int c)
		{
			lock (_sync)
			{
				if (_Index + c < BUFFER_SIZE)
				{
					return;
				}

				lock (_syncB)
				{
					var b = _Working;
					_Working = _Buffer;
					_Buffer = b;
					_Index = 0;
				}
			}
			ThreadPool.QueueUserWorkItem(Fill);
		}</pre>

Fragment 2 in file Server\Random.cs

<pre>private void CheckSwap(int c)
		{
			lock (_sync)
			{
				if (_Index + c < BUFFER_SIZE)
				{
					return;
				}

				lock (_syncB)
				{
					var b = _Working;
					_Working = _Buffer;
					_Buffer = b;
					_Index = 0;
				}
			}
			ThreadPool.QueueUserWorkItem(Fill);
		}</pre>

Fragment 3 in file Server\Random.cs

<pre>private void CheckSwap(int c)
		{
			lock (_sync)
			{
				if (_Index + c < BUFFER_SIZE)
				{
					return;
				}

				lock (_syncB)
				{
					var b = _Working;
					_Working = _Buffer;
					_Buffer = b;
					_Index = 0;
				}
			}
			ThreadPool.QueueUserWorkItem(Fill);
		}</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\GumpBackground.cs

<pre>public override void AppendTo( IGumpWriter disp )
		{
			disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_GumpID );
			disp.AppendLayout( m_Width );
			disp.AppendLayout( m_Height );
		}</pre>

Fragment 2 in file Server\Gumps\GumpImageTiled.cs

<pre>public override void AppendTo( IGumpWriter disp )
		{
			disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_Width );
			disp.AppendLayout( m_Height );
			disp.AppendLayout( m_GumpID );
		}</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>if (item.AtWorldPoint(x, y) &&
									(item.Z == newZ || ((item.Z + item.ItemData.Height) > newZ && (newZ + 15) > item.Z)) && !item.OnMoveOver(this))
								{
									return false;
								}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (item.AtWorldPoint(x, y) &&
										 (item.Z == newZ || ((item.Z + item.ItemData.Height) > newZ && (newZ + 15) > item.Z)) && !item.OnMoveOver(this))
								{
									return false;
								}</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(HashSet<Item> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(item => item.Deleted);
			}

			Write(set.Count);

			foreach (Item item in set)
			{
				Write(item);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(HashSet<Item> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(item => item.Deleted);
			}

			Write(set.Count);

			foreach (Item item in set)
			{
				Write(item);
			}
		}</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(HashSet<Mobile> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(mobile => mobile.Deleted);
			}

			Write(set.Count);

			foreach (Mobile mob in set)
			{
				Write(mob);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(HashSet<Mobile> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(mobile => mobile.Deleted);
			}

			Write(set.Count);

			foreach (Mobile mob in set)
			{
				Write(mob);
			}
		}</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(HashSet<BaseGuild> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(guild => guild.Disbanded);
			}

			Write(set.Count);

			foreach (BaseGuild guild in set)
			{
				Write(guild);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(HashSet<BaseGuild> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(guild => guild.Disbanded);
			}

			Write(set.Count);

			foreach (BaseGuild guild in set)
			{
				Write(guild);
			}
		}</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(HashSet<SaveData> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(data => data.Deleted);
			}

			Write(set.Count);

			foreach (SaveData data in set)
			{
				Write(data);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(HashSet<SaveData> set, bool tidy)
		{
			if (tidy)
			{
				set.RemoveWhere(data => data.Deleted);
			}

			Write(set.Count);

			foreach (SaveData data in set)
			{
				Write(data);
			}
		}</pre>

## Duplicated Code. Size: 101

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>int x = loc.m_X & 0x7FFF;
            int y = loc.m_Y & 0x3FFF;
            stream.Write((short)x);
            stream.Write((short)y);
            stream.Write((sbyte)loc.m_Z);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>int x = loc.m_X & 0x7FFF;
            int y = loc.m_Y & 0x3FFF;
            stream.Write((short)x);
            stream.Write((short)y);
            stream.Write((sbyte)loc.m_Z);</pre>

## Duplicated Code. Size: 100

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>{
			return (p.m_X >= (m_Location.m_X - range)) && (p.m_X <= (m_Location.m_X + range)) &&
				   (p.m_Y >= (m_Location.m_Y - range)) && (p.m_Y <= (m_Location.m_Y + range));
		}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>{
			return (p.m_X >= (m_Location.m_X - range)) && (p.m_X <= (m_Location.m_X + range)) &&
				   (p.m_Y >= (m_Location.m_Y - range)) && (p.m_Y <= (m_Location.m_Y + range));
		}</pre>

## Duplicated Code. Size: 100

### Duplicated Fragments:

Fragment 1 in file Server\MultiData.cs

<pre>allTiles[i].m_OffsetX = reader.ReadShort();
					allTiles[i].m_OffsetY = reader.ReadShort();
					allTiles[i].m_OffsetZ = reader.ReadShort();
					allTiles[i].m_Flags = reader.ReadInt();</pre>

Fragment 2 in file Server\MultiData.cs

<pre>allTiles[i].m_OffsetX = reader.ReadShort();
					allTiles[i].m_OffsetY = reader.ReadShort();
					allTiles[i].m_OffsetZ = reader.ReadShort();
					allTiles[i].m_Flags = reader.ReadInt();</pre>

## Duplicated Code. Size: 100

### Duplicated Fragments:

Fragment 1 in file Server\TileMatrix.cs

<pre>while (pCur < pEnd)
						{
							lists[pCur->m_X & 0x7][pCur->m_Y & 0x7].Add(pCur->m_ID, pCur->m_Z);
							pCur = pCur + 1;
						}

						var tiles = new StaticTile[8][][];</pre>

Fragment 2 in file Server\TileMatrixPatch.cs

<pre>while (pCur < pEnd)
								{
									lists[pCur->m_X & 0x7][pCur->m_Y & 0x7].Add(pCur->m_ID, pCur->m_Z);
									pCur = pCur + 1;
								}

								var tiles = new StaticTile[8][][];</pre>

## Duplicated Code. Size: 100

### Duplicated Fragments:

Fragment 1 in file Server\Utility.cs

<pre>{
			return (p1.m_X >= (p2.m_X - 18)) && (p1.m_X <= (p2.m_X + 18)) && (p1.m_Y >= (p2.m_Y - 18)) &&
				   (p1.m_Y <= (p2.m_Y + 18));
		}</pre>

Fragment 2 in file Server\Utility.cs

<pre>{
			return (p1.m_X >= (p2.m_X - 18)) && (p1.m_X <= (p2.m_X + 18)) && (p1.m_Y >= (p2.m_Y - 18)) &&
				   (p1.m_Y <= (p2.m_Y + 18));
		}</pre>

## Duplicated Code. Size: 98

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\GumpTextEntry.cs

<pre>disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_Width );
			disp.AppendLayout( m_Height );
			disp.AppendLayout( m_Hue );
			disp.AppendLayout( m_EntryID );</pre>

Fragment 2 in file Server\Gumps\GumpTextEntryLimited.cs

<pre>disp.AppendLayout( m_LayoutName );
			disp.AppendLayout( m_X );
			disp.AppendLayout( m_Y );
			disp.AppendLayout( m_Width );
			disp.AppendLayout( m_Height );
			disp.AppendLayout( m_Hue );
			disp.AppendLayout( m_EntryID );</pre>

## Duplicated Code. Size: 97

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>foreach (NetState state in eable)
                    {
                        Mobile m = state.Mobile;

                        if (m.CanSee(this) && m.InRange(m_Location, GetUpdateRange(m)))
                        {
                            SendInfoTo(state);
                        }
                    }

                    eable.Free();</pre>

Fragment 2 in file Server\Item.cs

<pre>foreach (NetState state in eable)
                {
                    Mobile m = state.Mobile;

                    if (m.CanSee(this) && m.InRange(m_Location, GetUpdateRange(m)))
                    {
                        SendInfoTo(state);
                    }
                }

                eable.Free();</pre>

## Duplicated Code. Size: 97

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>string s = Utility.UTF8.GetString(buffer);

			bool isSafe = true;

			for (int i = 0; isSafe && i < s.Length; ++i)
			{
				isSafe = IsSafeChar(s[i]);
			}</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>string s = Utility.UTF8.GetString(buffer);

			bool isSafe = true;

			for (int i = 0; isSafe && i < s.Length; ++i)
			{
				isSafe = IsSafeChar(s[i]);
			}</pre>

## Duplicated Code. Size: 95

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>{
                    try
                    {
                        using (StreamWriter op = new StreamWriter("delta-recursion.log", true))
                        {
                            op.WriteLine("# {0}", DateTime.UtcNow);
                            op.WriteLine(new StackTrace());
                            op.WriteLine();
                        }
                    }
                    catch
                    { }
                }</pre>

Fragment 2 in file Server\Item.cs

<pre>{
                    try
                    {
                        using (StreamWriter op = new StreamWriter("delta-recursion.log", true))
                        {
                            op.WriteLine("# {0}", DateTime.UtcNow);
                            op.WriteLine(new StackTrace());
                            op.WriteLine();
                        }
                    }
                    catch
                    { }
                }</pre>

## Duplicated Code. Size: 95

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>{
			if ((m_Index + 2) > m_Buffer.Length)
			{
				Flush();
			}

			m_Buffer[m_Index] = (byte)value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Index += 2;
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>{
			if ((m_Index + 2) > m_Buffer.Length)
			{
				Flush();
			}

			m_Buffer[m_Index] = (byte)value;
			m_Buffer[m_Index + 1] = (byte)(value >> 8);
			m_Index += 2;
		}</pre>

## Duplicated Code. Size: 94

### Duplicated Fragments:

Fragment 1 in file Server\Utility.cs

<pre>output.Write(byteIndex.ToString("X4"));
				output.Write("   ");
				output.Write(bytes.ToString());
				output.Write("  ");
				output.WriteLine(chars.ToString());</pre>

Fragment 2 in file Server\Utility.cs

<pre>output.Write(byteIndex.ToString("X4"));
				output.Write("   ");
				output.Write(bytes.ToString());
				output.Write("  ");
				output.WriteLine(chars.ToString());</pre>

## Duplicated Code. Size: 94

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write(serial);
			m_Stream.Write((short)graphic);
			m_Stream.Write((byte)type);
			m_Stream.Write((short)hue);
			m_Stream.Write((short)font);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write(serial);
			m_Stream.Write((short)graphic);
			m_Stream.Write((byte)type);
			m_Stream.Write((short)hue);
			m_Stream.Write((short)font);</pre>

Fragment 3 in file Server\Network\Packets.cs

<pre>m_Stream.Write(serial);
			m_Stream.Write((short)graphic);
			m_Stream.Write((byte)type);
			m_Stream.Write((short)hue);
			m_Stream.Write((short)font);</pre>

## Duplicated Code. Size: 94

### Duplicated Fragments:

Fragment 1 in file Server\Random.cs

<pre>private void _GetBytes(byte[] b)
		{
			int c = b.Length;

			CheckSwap(c);

			lock (_sync)
			{
				Buffer.BlockCopy(_Working, _Index, b, 0, c);
				_Index += c;
			}
		}</pre>

Fragment 2 in file Server\Random.cs

<pre>private void _GetBytes(byte[] b)
		{
			int c = b.Length;

			CheckSwap(c);

			lock (_sync)
			{
				Buffer.BlockCopy(_Working, _Index, b, 0, c);
				_Index += c;
			}
		}</pre>

Fragment 3 in file Server\Random.cs

<pre>private void _GetBytes(byte[] b)
		{
			int c = b.Length;

			CheckSwap(c);

			lock (_sync)
			{
				Buffer.BlockCopy(_Working, _Index, b, 0, c);
				_Index += c;
			}
		}</pre>

## Duplicated Code. Size: 92

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)m.ManaMax);
			m_Stream.Write((short)m.Mana);

			m_Stream.Write((short)m.StamMax);
			m_Stream.Write((short)m.Stam);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)m.Stam);
			m_Stream.Write((short)m.StamMax);

			m_Stream.Write((short)m.Mana);
			m_Stream.Write((short)m.ManaMax);</pre>

## Duplicated Code. Size: 91

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>item.AtWorldPoint(oldX, oldY) &&
									(item.Z == oldZ || ((item.Z + item.ItemData.Height) > oldZ && (oldZ + 15) > item.Z)) && !item.OnMoveOff(this)</pre>

Fragment 2 in file Server\Mobile.cs

<pre>item.AtWorldPoint(oldX, oldY) &&
									(item.Z == oldZ || ((item.Z + item.ItemData.Height) > oldZ && (oldZ + 15) > item.Z)) && !item.OnMoveOff(this)</pre>

## Duplicated Code. Size: 91

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>{
                                    if (ns.ContainerGridLines)
                                    {
                                        ns.Send(new ContainerContentUpdate6017(this));
                                    }
                                    else
                                    {
                                        ns.Send(new ContainerContentUpdate(this));
                                    }

                                    if (ObjectPropertyList.Enabled)
                                    {
                                        ns.Send(OPLPacket);
                                    }
                                }</pre>

Fragment 2 in file Server\Item.cs

<pre>{
                                            if (ns.ContainerGridLines)
                                            {
                                                ns.Send(new ContainerContentUpdate6017(this));
                                            }
                                            else
                                            {
                                                ns.Send(new ContainerContentUpdate(this));
                                            }

                                            if (ObjectPropertyList.Enabled)
                                            {
                                                ns.Send(OPLPacket);
                                            }
                                        }</pre>

Fragment 3 in file Server\Item.cs

<pre>{
                                                if (ns.ContainerGridLines)
                                                {
                                                    ns.Send(new ContainerContentUpdate6017(this));
                                                }
                                                else
                                                {
                                                    ns.Send(new ContainerContentUpdate(this));
                                                }

                                                if (ObjectPropertyList.Enabled)
                                                {
                                                    ns.Send(OPLPacket);
                                                }
                                            }</pre>

## Duplicated Code. Size: 91

### Duplicated Fragments:

Fragment 1 in file Server\Random.cs

<pre>private void _GetBytes(byte[] b, int offset, int count)
		{
			CheckSwap(count);

			lock (_sync)
			{
				Buffer.BlockCopy(_Working, _Index, b, offset, count);
				_Index += count;
			}
		}</pre>

Fragment 2 in file Server\Random.cs

<pre>private void _GetBytes(byte[] b, int offset, int count)
		{
			CheckSwap(count);

			lock (_sync)
			{
				Buffer.BlockCopy(_Working, _Index, b, offset, count);
				_Index += count;
			}
		}</pre>

Fragment 3 in file Server\Random.cs

<pre>private void _GetBytes(byte[] b, int offset, int count)
		{
			CheckSwap(count);

			lock (_sync)
			{
				Buffer.BlockCopy(_Working, _Index, b, offset, count);
				_Index += count;
			}
		}</pre>

## Duplicated Code. Size: 90

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_CompiledLength = length;

					if (length > BufferSize || (m_State & State.Static) != 0)
					{
						m_CompiledBuffer = new byte[length];
					}
					else
					{
						lock (m_Buffers)
							m_CompiledBuffer = m_Buffers.AcquireBuffer();
						m_State |= State.Buffered;
					}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_CompiledLength = length;

				if (length > BufferSize || (m_State & State.Static) != 0)
				{
					m_CompiledBuffer = new byte[length];
				}
				else
				{
					lock (m_Buffers)
						m_CompiledBuffer = m_Buffers.AcquireBuffer();
					m_State |= State.Buffered;
				}</pre>

## Duplicated Code. Size: 89

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>int hue;

				if (m_NameHue != -1)
				{
					hue = m_NameHue;
				}
				else if (IsStaff())
				{
					hue = 11;
				}
				else
				{
					hue = Notoriety.GetHue(Notoriety.Compute(from, this));
				}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>int hue;

			if (m_NameHue != -1)
			{
				hue = m_NameHue;
			}
			else if (IsStaff())
			{
				hue = 11;
			}
			else
			{
				hue = Notoriety.GetHue(Notoriety.Compute(from, this));
			}</pre>

## Duplicated Code. Size: 89

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)0); // itemID
			m_Stream.Write((short)target.X);
			m_Stream.Write((short)target.Y);
			m_Stream.Write((sbyte)target.Z);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)target.X);
			m_Stream.Write((short)target.Y);
			m_Stream.Write((sbyte)target.Z);
			m_Stream.Write((byte)0); // speed</pre>

Fragment 3 in file Server\Network\Packets.cs

<pre>m_Stream.Write((short)0); // volume
			m_Stream.Write((short)target.X);
			m_Stream.Write((short)target.Y);
			m_Stream.Write((short)target.Z);</pre>

## Duplicated Code. Size: 88

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>public override void OnCancel(Mobile from)
			{
				if (m_CallbackHandlesCancel && m_Callback != null)
				{
					m_Callback(from, "", m_State);
				}
				else if (m_CancelCallback != null)
				{
					m_CancelCallback(from, "", m_State);
				}
			}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>public override void OnCancel(Mobile from)
			{
				if (m_CallbackHandlesCancel && m_Callback != null)
				{
					m_Callback(from, "", m_State);
				}
				else if (m_CancelCallback != null)
				{
					m_CancelCallback(from, "", m_State);
				}
			}</pre>

## Duplicated Code. Size: 88

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>{
				m_Stream.Write((byte)0x02);

				m_Stream.Write(item.Serial);

				itemID &= 0x3FFF;

				m_Stream.Write((short)itemID);

				m_Stream.Write((byte)0);
			}</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>{
                m_Stream.Write((byte)0x02);
                m_Stream.Write(item.Serial);

                itemID &= 0x3FFF;

                m_Stream.Write((ushort)itemID);

                m_Stream.Write((byte)0);
            }</pre>

## Duplicated Code. Size: 87

### Duplicated Fragments:

Fragment 1 in file Server\Customs Framework\Central Core\Base Types\SaveData.cs

<pre>Type dataType = GetType();
			_TypeID = World._DataTypes.IndexOf(dataType);

			if (_TypeID == -1)
			{
				World._DataTypes.Add(dataType);
				_TypeID = World._DataTypes.Count - 1;
			}</pre>

Fragment 2 in file Server\Customs Framework\Central Core\Base Types\SaveData.cs

<pre>Type dataType = GetType();
			_TypeID = World._DataTypes.IndexOf(dataType);

			if (_TypeID == -1)
			{
				World._DataTypes.Add(dataType);
				_TypeID = World._DataTypes.Count - 1;
			}</pre>

## Duplicated Code. Size: 87

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>Type ourType = GetType();
            m_TypeRef = World.m_ItemTypes.IndexOf(ourType);

            if (m_TypeRef == -1)
            {
                World.m_ItemTypes.Add(ourType);
                m_TypeRef = World.m_ItemTypes.Count - 1;
            }</pre>

Fragment 2 in file Server\Item.cs

<pre>Type ourType = GetType();
            m_TypeRef = World.m_ItemTypes.IndexOf(ourType);

            if (m_TypeRef == -1)
            {
                World.m_ItemTypes.Add(ourType);
                m_TypeRef = World.m_ItemTypes.Count - 1;
            }</pre>

## Duplicated Code. Size: 85

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>if (CanSee(aggressor) && m_NetState != null)
				{
					m_NetState.Send(MobileIncoming.Create(m_NetState, this, aggressor));
				}

				if (Combatant == null)
				{
					setCombatant = true;
				}

				UpdateAggrExpire();</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (CanSee(aggressor) && m_NetState != null)
				{
					m_NetState.Send(MobileIncoming.Create(m_NetState, this, aggressor));
				}

				if (Combatant == null)
				{
					setCombatant = true;
				}

				UpdateAggrExpire();</pre>

## Duplicated Code. Size: 85

### Duplicated Fragments:

Fragment 1 in file Server\Persistence\DynamicSaveStrategy.cs

<pre>private void SaveTypeDatabases()
        {
            this.SaveTypeDatabase(World.ItemTypesPath, World.m_ItemTypes);
            this.SaveTypeDatabase(World.MobileTypesPath, World.m_MobileTypes);
            this.SaveTypeDatabase(World.DataTypesPath, World._DataTypes);
        }</pre>

Fragment 2 in file Server\Persistence\ParallelSaveStrategy.cs

<pre>private void SaveTypeDatabases()
        {
            this.SaveTypeDatabase(World.ItemTypesPath, World.m_ItemTypes);
            this.SaveTypeDatabase(World.MobileTypesPath, World.m_MobileTypes);
            this.SaveTypeDatabase(World.DataTypesPath, World._DataTypes);
        }</pre>

## Duplicated Code. Size: 85

### Duplicated Fragments:

Fragment 1 in file Server\Map.cs

<pre>BaseMulti m = (BaseMulti)item;
				MultiComponentList mcl = m.Components;

				Sector start = GetMultiMinSector(item.Location, mcl);
				Sector end = GetMultiMaxSector(item.Location, mcl);</pre>

Fragment 2 in file Server\Map.cs

<pre>BaseMulti m = (BaseMulti)item;
				MultiComponentList mcl = m.Components;

				Sector start = GetMultiMinSector(item.Location, mcl);
				Sector end = GetMultiMaxSector(item.Location, mcl);</pre>

Fragment 3 in file Server\Map.cs

<pre>BaseMulti m = (BaseMulti)item;
				MultiComponentList mcl = m.Components;

				Sector start = GetMultiMinSector(item.Location, mcl);
				Sector end = GetMultiMaxSector(item.Location, mcl);</pre>

## Duplicated Code. Size: 84

### Duplicated Fragments:

Fragment 1 in file Server\Effects.cs

<pre>IEntity from,
			IEntity to,
			int itemID,
			int speed,
			int duration,
			bool fixedDirection,
			bool explodes,
			int hue,
			int renderMode,
			int effect,
			int explodeEffect,
			int explodeSound,
			EffectLayer layer,
			int unknown</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>IEntity from,
			IEntity to,
			int itemID,
			int speed,
			int duration,
			bool fixedDirection,
			bool explodes,
			int hue,
			int renderMode,
			int effect,
			int explodeEffect,
			int explodeSound,
			EffectLayer layer,
			int unknown</pre>

## Duplicated Code. Size: 84

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>if (m.X == x && m.Y == y && (m.Z + 15) > newZ && (newZ + 15) > m.Z && !m.OnMoveOver(this))
								{
									return false;
								}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (m.X == x && m.Y == y && (m.Z + 15) > newZ && (newZ + 15) > m.Z && !m.OnMoveOver(this))
								{
									return false;
								}</pre>

## Duplicated Code. Size: 84

### Duplicated Fragments:

Fragment 1 in file Server\ScriptCompiler.cs

<pre>bool valid = true;

									for (int i = 0; i < bytes.Length; ++i)
									{
										if (bytes[i] != hashCode[i])
										{
											valid = false;
											break;
										}
									}</pre>

Fragment 2 in file Server\ScriptCompiler.cs

<pre>bool valid = true;

									for (int i = 0; i < bytes.Length; ++i)
									{
										if (bytes[i] != hashCode[i])
										{
											valid = false;
											break;
										}
									}</pre>

## Duplicated Code. Size: 83

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new MobileUpdate(m));
				state.Send(new MobileUpdate(m));

				m.CheckLightLevels(true);

				state.Send(new MobileUpdate(m));</pre>

Fragment 2 in file Server\Network\PacketHandlers.cs

<pre>state.Send(new MobileUpdate(m));
				state.Send(new MobileUpdate(m));

				m.CheckLightLevels(true);

				state.Send(new MobileUpdate(m));</pre>

## Duplicated Code. Size: 83

### Duplicated Fragments:

Fragment 1 in file Server\World.cs

<pre>{
			var results = new List<SaveData>();

			foreach (SaveData data in _Data.Values)
			{
				if (data.GetType() == type)
				{
					results.Add(data);
				}
			}

			return results;
		}</pre>

Fragment 2 in file Server\World.cs

<pre>{
			var results = new List<SaveData>();

			foreach (SaveData data in _Data.Values)
			{
				if (data.GetType() == type)
				{
					results.Add(data);
				}
			}

			return results;
		}</pre>

## Duplicated Code. Size: 82

### Duplicated Fragments:

Fragment 1 in file Server\Persistence\ParallelSaveStrategy.cs

<pre>public override void ProcessDecay()
        {
            while (this._decayQueue.Count > 0)
            {
                Item item = this._decayQueue.Dequeue();

                if (item.OnDecay())
                {
                    item.Delete();
                }
            }
        }</pre>

Fragment 2 in file Server\Persistence\StandardSaveStrategy.cs

<pre>public override void ProcessDecay()
        {
            while (this._decayQueue.Count > 0)
            {
                Item item = this._decayQueue.Dequeue();

                if (item.OnDecay())
                {
                    item.Delete();
                }
            }
        }</pre>

## Duplicated Code. Size: 81

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\GumpButton.cs

<pre>public GumpButtonType Type
		{
			get
			{
				return m_Type;
			}
			set
			{
				if ( m_Type != value )
				{
					m_Type = value;

					Gump parent = Parent;

					if ( parent != null )
					{
						parent.Invalidate();
					}
				}
			}
		}</pre>

Fragment 2 in file Server\Gumps\GumpImageTileButton.cs

<pre>public GumpButtonType Type
		{
			get
			{
				return m_Type;
			}
			set
			{
				if( m_Type != value )
				{
					m_Type = value;

					Gump parent = Parent;

					if( parent != null )
					{
						parent.Invalidate();
					}
				}
			}
		}</pre>

## Duplicated Code. Size: 81

### Duplicated Fragments:

Fragment 1 in file Server\Random.cs

<pre>public void NextBytes(byte[] b)
		{
			int c = b.Length;

			if (c >= LARGE_REQUEST)
			{
				SafeNativeMethods.rdrand_get_bytes(c, b);
				return;
			}
			_GetBytes(b);
		}</pre>

Fragment 2 in file Server\Random.cs

<pre>public void NextBytes(byte[] b)
		{
			int c = b.Length;

			if (c >= LARGE_REQUEST)
			{
				SafeNativeMethods.rdrand_get_bytes(c, b);
				return;
			}
			_GetBytes(b);
		}</pre>

## Duplicated Code. Size: 80

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>m != this && m.X == oldX && m.Y == oldY && (m.Z + 15) > oldZ && (oldZ + 15) > m.Z && !m.OnMoveOff(this)</pre>

Fragment 2 in file Server\Mobile.cs

<pre>m != this && m.X == oldX && m.Y == oldY && (m.Z + 15) > oldZ && (oldZ + 15) > m.Z && !m.OnMoveOff(this)</pre>

## Duplicated Code. Size: 80

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x03);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)0x03);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);</pre>

## Duplicated Code. Size: 80

### Duplicated Fragments:

Fragment 1 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x10);</pre>

Fragment 2 in file Server\Network\Packets.cs

<pre>m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x00);
            m_Stream.Write((byte)0x10);</pre>

## Duplicated Code. Size: 78

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>{
            if (m_Parent is Item)
            {
                ((Item)m_Parent).OnSubItemAdded(item);
            }
            else if (m_Parent is Mobile)
            {
                ((Mobile)m_Parent).OnSubItemAdded(item);
            }
        }</pre>

Fragment 2 in file Server\Item.cs

<pre>{
            if (m_Parent is Item)
            {
                ((Item)m_Parent).OnSubItemAdded(item);
            }
            else if (m_Parent is Mobile)
            {
                ((Mobile)m_Parent).OnSubItemAdded(item);
            }
        }</pre>

## Duplicated Code. Size: 78

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>{
            if (m_Parent is Item)
            {
                ((Item)m_Parent).OnSubItemRemoved(item);
            }
            else if (m_Parent is Mobile)
            {
                ((Mobile)m_Parent).OnSubItemRemoved(item);
            }
        }</pre>

Fragment 2 in file Server\Item.cs

<pre>{
            if (m_Parent is Item)
            {
                ((Item)m_Parent).OnSubItemRemoved(item);
            }
            else if (m_Parent is Mobile)
            {
                ((Mobile)m_Parent).OnSubItemRemoved(item);
            }
        }</pre>

## Duplicated Code. Size: 78

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>{
            if (m_Parent is Item)
            {
                ((Item)m_Parent).OnSubItemBounceCleared(item);
            }
            else if (m_Parent is Mobile)
            {
                ((Mobile)m_Parent).OnSubItemBounceCleared(item);
            }
        }</pre>

Fragment 2 in file Server\Item.cs

<pre>{
            if (m_Parent is Item)
            {
                ((Item)m_Parent).OnSubItemBounceCleared(item);
            }
            else if (m_Parent is Mobile)
            {
                ((Mobile)m_Parent).OnSubItemBounceCleared(item);
            }
        }</pre>

## Duplicated Code. Size: 78

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>{
				if (CanRegenHits)
				{
					if (m_HitsTimer == null)
					{
						m_HitsTimer = new HitsTimer(this);
					}

					m_HitsTimer.Start();
				}
				else if (m_HitsTimer != null)
				{
					m_HitsTimer.Stop();
				}
			}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>{
					if (CanRegenHits)
					{
						if (m_HitsTimer == null)
						{
							m_HitsTimer = new HitsTimer(this);
						}

						m_HitsTimer.Start();
					}
					else if (m_HitsTimer != null)
					{
						m_HitsTimer.Stop();
					}
				}</pre>

## Duplicated Code. Size: 78

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>{
				if (CanRegenStam)
				{
					if (m_StamTimer == null)
					{
						m_StamTimer = new StamTimer(this);
					}

					m_StamTimer.Start();
				}
				else if (m_StamTimer != null)
				{
					m_StamTimer.Stop();
				}
			}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>{
					if (CanRegenStam)
					{
						if (m_StamTimer == null)
						{
							m_StamTimer = new StamTimer(this);
						}

						m_StamTimer.Start();
					}
					else if (m_StamTimer != null)
					{
						m_StamTimer.Stop();
					}
				}</pre>

## Duplicated Code. Size: 78

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>{
				if (CanRegenMana)
				{
					if (m_ManaTimer == null)
					{
						m_ManaTimer = new ManaTimer(this);
					}

					m_ManaTimer.Start();
				}
				else if (m_ManaTimer != null)
				{
					m_ManaTimer.Stop();
				}
			}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>{
					if (CanRegenMana)
					{
						if (m_ManaTimer == null)
						{
							m_ManaTimer = new ManaTimer(this);
						}

						m_ManaTimer.Start();
					}
					else if (m_ManaTimer != null)
					{
						m_ManaTimer.Stop();
					}
				}</pre>

## Duplicated Code. Size: 77

### Duplicated Fragments:

Fragment 1 in file Server\Effects.cs

<pre>p.Acquire();

				foreach (NetState state in eable)
				{
					state.Mobile.ProcessDelta();
					state.Send(p);
				}

				p.Release();

				eable.Free();</pre>

Fragment 2 in file Server\Effects.cs

<pre>p.Acquire();

				foreach (NetState state in eable)
				{
					state.Mobile.ProcessDelta();
					state.Send(p);
				}

				p.Release();

				eable.Free();</pre>

## Duplicated Code. Size: 77

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>if (m_Blessed || m_YellowHealthbar)
			{
				flags |= 0x08;
			}

			if (m_Warmode)
			{
				flags |= 0x40;
			}

			if (m_Hidden)
			{
				flags |= 0x80;
			}

            if (m_IgnoreMobiles)
            {
                flags |= 0x10;
            }

			return flags;</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (m_Blessed || m_YellowHealthbar)
			{
				flags |= 0x08;
			}

			if (m_Warmode)
			{
				flags |= 0x40;
			}

			if (m_Hidden)
			{
				flags |= 0x80;
			}

            if (m_IgnoreMobiles)
            {
                flags |= 0x10;
            }

			return flags;</pre>

## Duplicated Code. Size: 75

### Duplicated Fragments:

Fragment 1 in file Server\Item.cs

<pre>if (Parent is Mobile)
            {
                ((Mobile)Parent).RemoveItem(this);
            }
            else if (Parent is Item)
            {
                ((Item)Parent).RemoveItem(this);
            }</pre>

Fragment 2 in file Server\Item.cs

<pre>if (Parent is Mobile)
            {
                ((Mobile)Parent).RemoveItem(this);
            }
            else if (Parent is Item)
            {
                ((Item)Parent).RemoveItem(this);
            }</pre>

## Duplicated Code. Size: 75

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>int bound = m_Index + fixedLength;
			int end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			StringBuilder sb = new StringBuilder();

			int c;</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>int bound = m_Index + fixedLength;
			int end = bound;

			if (bound > m_Size)
			{
				bound = m_Size;
			}

			StringBuilder sb = new StringBuilder();

			int c;</pre>

## Duplicated Code. Size: 74

### Duplicated Fragments:

Fragment 1 in file Server\Map.cs

<pre>var checkTop = checkZ + id.CalcHeight;

					if (checkTop == checkZ && !id.Surface)
					{
						++checkTop;
					}

					if (checkTop > z && checkTop <= currentZ)
					{
						z = checkTop;
					}</pre>

Fragment 2 in file Server\Map.cs

<pre>var checkTop = checkZ + id.CalcHeight;

					if (checkTop == checkZ && !id.Surface)
					{
						++checkTop;
					}

					if (checkTop > z && checkTop <= currentZ)
					{
						z = checkTop;
					}</pre>

## Duplicated Code. Size: 74

### Duplicated Fragments:

Fragment 1 in file Server\Network\Compression.cs

<pre>while (bitCount >= 8)
							{
								bitCount -= 8;

								if (pOutput < pOutputEnd)
								{
									*pOutput++ = (byte)(bitValue >> bitCount);
								}
								else
								{
									length = 0;
									return;
								}
							}</pre>

Fragment 2 in file Server\Network\Compression.cs

<pre>while (bitCount >= 8)
						{
							bitCount -= 8;

							if (pOutput < pOutputEnd)
							{
								*pOutput++ = (byte)(bitValue >> bitCount);
							}
							else
							{
								length = 0;
								return;
							}
						}</pre>

## Duplicated Code. Size: 74

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketWriter.cs

<pre>{
			m_Buffer[0] = (byte)(value >> 8);
			m_Buffer[1] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 2);
		}</pre>

Fragment 2 in file Server\Network\PacketWriter.cs

<pre>{
			m_Buffer[0] = (byte)(value >> 8);
			m_Buffer[1] = (byte)value;

			m_Stream.Write(m_Buffer, 0, 2);
		}</pre>

## Duplicated Code. Size: 73

### Duplicated Fragments:

Fragment 1 in file Server\Persistence\FileQueue.cs

<pre>this.active[slot] = new Chunk(this, slot, page.buffer, 0, page.length);

                        this.callback(this.active[slot]);</pre>

Fragment 2 in file Server\Persistence\FileQueue.cs

<pre>this.active[slot] = new Chunk(this, slot, page.buffer, 0, page.length);

                    this.callback(this.active[slot]);</pre>

## Duplicated Code. Size: 73

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(Map value)
		{
			if (value != null)
			{
				Write((byte)value.MapIndex);
			}
			else
			{
				Write((byte)0xFF);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(Map value)
		{
			if (value != null)
			{
				Write((byte)value.MapIndex);
			}
			else
			{
				Write((byte)0xFF);
			}
		}</pre>

## Duplicated Code. Size: 73

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(Race value)
		{
			if (value != null)
			{
				Write((byte)value.RaceIndex);
			}
			else
			{
				Write((byte)0xFF);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(Race value)
		{
			if (value != null)
			{
				Write((byte)value.RaceIndex);
			}
			else
			{
				Write((byte)0xFF);
			}
		}</pre>

## Duplicated Code. Size: 72

### Duplicated Fragments:

Fragment 1 in file Server\Gumps\Gump.cs

<pre>int x,
			int y,
			int normalID,
			int pressedID,
			int buttonID,
			GumpButtonType type,
			int param,
			int itemID,
			int hue,
			int width,
			int height,
			int localizedTooltip</pre>

Fragment 2 in file Server\Gumps\GumpImageTileButton.cs

<pre>int x, int y, int normalID, int pressedID, int buttonID, GumpButtonType type, int param, int itemID, int hue, int width, int height, int localizedTooltip</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Server\Mobile.cs

<pre>BankBox box = FindBankNoCreate();

			if (box != null && box.Opened)
			{
				box.Close();
			}

			if (m_NetState != null)
			{
				m_NetState.CancelAllTrades();
			}</pre>

Fragment 2 in file Server\Mobile.cs

<pre>if (m_NetState != null)
					{
						m_NetState.CancelAllTrades();
					}

					BankBox box = FindBankNoCreate();

					if (box != null && box.Opened)
					{
						box.Close();
					}</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>(m_Data[m_Index++] << 24) | (m_Data[m_Index++] << 16) | (m_Data[m_Index++] << 8) | m_Data[m_Index++]</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>(m_Data[m_Index++] << 24) | (m_Data[m_Index++] << 16) | (m_Data[m_Index++] << 8) | m_Data[m_Index++]</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Server\Network\PacketReader.cs

<pre>{
			if ((m_Index + 2) > m_Size)
			{
				return 0;
			}

			return (short)((m_Data[m_Index++] << 8) | m_Data[m_Index++]);
		}</pre>

Fragment 2 in file Server\Network\PacketReader.cs

<pre>{
			if ((m_Index + 2) > m_Size)
			{
				return 0;
			}

			return (ushort)((m_Data[m_Index++] << 8) | m_Data[m_Index++]);
		}</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(Item value)
		{
			if (value == null || value.Deleted)
			{
				Write(Serial.MinusOne);
			}
			else
			{
				Write(value.Serial);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(Item value)
		{
			if (value == null || value.Deleted)
			{
				Write(Serial.MinusOne);
			}
			else
			{
				Write(value.Serial);
			}
		}</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(Mobile value)
		{
			if (value == null || value.Deleted)
			{
				Write(Serial.MinusOne);
			}
			else
			{
				Write(value.Serial);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(Mobile value)
		{
			if (value == null || value.Deleted)
			{
				Write(Serial.MinusOne);
			}
			else
			{
				Write(value.Serial);
			}
		}</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Server\Serialization.cs

<pre>public override void Write(SaveData value)
		{
			if (value == null || value.Deleted)
			{
				Write(CustomSerial.MinusOne);
			}
			else
			{
				Write(value.Serial);
			}
		}</pre>

Fragment 2 in file Server\Serialization.cs

<pre>public override void Write(SaveData value)
		{
			if (value == null || value.Deleted)
			{
				Write(CustomSerial.MinusOne);
			}
			else
			{
				Write(value.Serial);
			}
		}</pre>