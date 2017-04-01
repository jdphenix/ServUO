# Statistics

Total codebase size: 128976

Code to analyze: 9667

Total size of duplicated fragments: 21140

# Detected Duplicates

## Duplicated Code. Size: 1536

### Duplicated Fragments:

Fragment 1 in file Ultima\TileData.cs

<pre>Tex.Write(";" + (((tile.Flags & TileFlag.Background) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Weapon) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Transparent) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Translucent) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Wall) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Damaging) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Impassable) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Wet) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Unknown1) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Surface) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Bridge) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Generic) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Window) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.NoShoot) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.ArticleA) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.ArticleAn) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Internal) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Foliage) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.PartialHue) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Unknown2) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Map) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Container) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Wearable) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.LightSource) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Animation) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.HoverOver) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Unknown3) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Armor) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Roof) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Door) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.StairBack) != 0) ? "1" : "0"));
					Tex.WriteLine(";" + (((tile.Flags & TileFlag.StairRight) != 0) ? "1" : "0"));</pre>

Fragment 2 in file Ultima\TileData.cs

<pre>Tex.Write(";" + (((tile.Flags & TileFlag.Background) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Weapon) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Transparent) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Translucent) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Wall) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Damaging) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Impassable) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Wet) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Unknown1) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Surface) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Bridge) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Generic) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Window) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.NoShoot) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.ArticleA) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.ArticleAn) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Internal) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Foliage) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.PartialHue) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Unknown2) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Map) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Container) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Wearable) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.LightSource) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Animation) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.HoverOver) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Unknown3) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Armor) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Roof) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.Door) != 0) ? "1" : "0"));
					Tex.Write(";" + (((tile.Flags & TileFlag.StairBack) != 0) ? "1" : "0"));
					Tex.WriteLine(";" + (((tile.Flags & TileFlag.StairRight) != 0) ? "1" : "0"));</pre>

## Duplicated Code. Size: 657

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>private static void GetFileIndex(
			int body, int fileType, int action, int direction, out FileIndex fileIndex, out int index)
		{
			switch (fileType)
			{
				default:
				case 1:
					fileIndex = m_FileIndex;
					if (body < 200)
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}
					break;
				case 2:
					fileIndex = m_FileIndex2;
					if (body < 200)
					{
						index = body * 110;
					}
					else
					{
						index = 22000 + ((body - 200) * 65);
					}
					break;
				case 3:
					fileIndex = m_FileIndex3;
					if (body < 300)
					{
						index = body * 65;
					}
					else if (body < 400)
					{
						index = 33000 + ((body - 300) * 110);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}
					break;
				case 4:
					fileIndex = m_FileIndex4;
					if (body < 200)
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}
					break;
				case 5:
					fileIndex = m_FileIndex5;
					if ((body < 200) && (body != 34)) // looks strange, though it works.
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}
					break;
			}

			index += action * 5;

			if (direction <= 4)
			{
				index += direction;
			}
			else
			{
				index += direction - (direction - 4) * 2;
			}
		}</pre>

Fragment 2 in file Ultima\Animations.cs

<pre>/// <summary>
		///     Gets Fileseek index based on fileType,body,action,direction
		/// </summary>
		/// <param name="body"></param>
		/// <param name="action"></param>
		/// <param name="direction"></param>
		/// <param name="fileType">animX</param>
		/// <param name="fileIndex"></param>
		/// <param name="index"></param>
		private static void GetFileIndex(
			int body, int action, int direction, int fileType, out FileIndex fileIndex, out int index)
		{
			switch (fileType)
			{
				default:
				case 1:
					fileIndex = m_FileIndex;
					if (body < 200)
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
				case 2:
					fileIndex = m_FileIndex2;
					if (body < 200)
					{
						index = body * 110;
					}
					else
					{
						index = 22000 + ((body - 200) * 65);
					}

					break;
				case 3:
					fileIndex = m_FileIndex3;
					if (body < 300)
					{
						index = body * 65;
					}
					else if (body < 400)
					{
						index = 33000 + ((body - 300) * 110);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
				case 4:
					fileIndex = m_FileIndex4;
					if (body < 200)
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
				case 5:
					fileIndex = m_FileIndex5;
					if ((body < 200) && (body != 34)) // looks strange, though it works.
					{
						index = body * 110;
					}
					else if (body < 400)
					{
						index = 22000 + ((body - 200) * 65);
					}
					else
					{
						index = 35000 + ((body - 400) * 175);
					}

					break;
			}

			index += action * 5;

			if (direction <= 4)
			{
				index += direction;
			}
			else
			{
				index += direction - (direction - 4) * 2;
			}
		}</pre>

## Duplicated Code. Size: 529

### Duplicated Fragments:

Fragment 1 in file Ultima\Hues.cs

<pre>{
			BitmapData bd = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format16bppArgb1555);

			int stride = bd.Stride >> 1;
			int width = bd.Width;
			int height = bd.Height;
			int delta = stride - width;

			var pBuffer = (ushort*)bd.Scan0;
			ushort* pLineEnd = pBuffer + width;
			ushort* pImageEnd = pBuffer + (stride * height);

			if (onlyHueGrayPixels)
			{
				int c;
				int r;
				int g;
				int b;

				while (pBuffer < pImageEnd)
				{
					while (pBuffer < pLineEnd)
					{
						c = *pBuffer;
						if (c != 0)
						{
							r = (c >> 10) & 0x1F;
							g = (c >> 5) & 0x1F;
							b = c & 0x1F;
							if (r == g && r == b)
							{
								*pBuffer = (ushort)Colors[(c >> 10) & 0x1F];
							}
						}
						++pBuffer;
					}

					pBuffer += delta;
					pLineEnd += stride;
				}
			}
			else
			{
				while (pBuffer < pImageEnd)
				{
					while (pBuffer < pLineEnd)
					{
						if (*pBuffer != 0)
						{
							*pBuffer = (ushort)Colors[(*pBuffer >> 10) & 0x1F];
						}
						++pBuffer;
					}

					pBuffer += delta;
					pLineEnd += stride;
				}
			}

			bmp.UnlockBits(bd);
		}</pre>

Fragment 2 in file Ultima\Hues.cs

<pre>{
			BitmapData bd = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format16bppArgb1555);

			int stride = bd.Stride >> 1;
			int width = bd.Width;
			int height = bd.Height;
			int delta = stride - width;

			var pBuffer = (ushort*)bd.Scan0;
			ushort* pLineEnd = pBuffer + width;
			ushort* pImageEnd = pBuffer + (stride * height);

			if (onlyHueGrayPixels)
			{
				int c;
				int r;
				int g;
				int b;

				while (pBuffer < pImageEnd)
				{
					while (pBuffer < pLineEnd)
					{
						c = *pBuffer;
						if (c != 0)
						{
							r = (c >> 10) & 0x1F;
							g = (c >> 5) & 0x1F;
							b = c & 0x1F;
							if (r == g && r == b)
							{
								*pBuffer = (ushort)Colors[(c >> 10) & 0x1F];
							}
						}
						++pBuffer;
					}

					pBuffer += delta;
					pLineEnd += stride;
				}
			}
			else
			{
				while (pBuffer < pImageEnd)
				{
					while (pBuffer < pLineEnd)
					{
						if (*pBuffer != 0)
						{
							*pBuffer = (ushort)Colors[(*pBuffer >> 10) & 0x1F];
						}
						++pBuffer;
					}

					pBuffer += delta;
					pLineEnd += stride;
				}
			}

			bmp.UnlockBits(bd);
		}</pre>

## Duplicated Code. Size: 396

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>int centerx = m_Max.X - (int)(Math.Round((m_Max.X - m_Min.X) / 2.0));
						int centery = m_Max.Y - (int)(Math.Round((m_Max.Y - m_Min.Y) / 2.0));

						m_Min = m_Max = Point.Empty;
						int i = 0;
						for (; i < m_SortedTiles.Length; i++)
						{
							m_SortedTiles[i].m_OffsetX -= (short)centerx;
							m_SortedTiles[i].m_OffsetY -= (short)centery;
							if (m_SortedTiles[i].m_OffsetX < m_Min.X)
							{
								m_Min.X = m_SortedTiles[i].m_OffsetX;
							}
							if (m_SortedTiles[i].m_OffsetX > m_Max.X)
							{
								m_Max.X = m_SortedTiles[i].m_OffsetX;
							}

							if (m_SortedTiles[i].m_OffsetY < m_Min.Y)
							{
								m_Min.Y = m_SortedTiles[i].m_OffsetY;
							}
							if (m_SortedTiles[i].m_OffsetY > m_Max.Y)
							{
								m_Max.Y = m_SortedTiles[i].m_OffsetY;
							}
						}</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>int centerx = m_Max.X - (int)(Math.Round((m_Max.X - m_Min.X) / 2.0));
						int centery = m_Max.Y - (int)(Math.Round((m_Max.Y - m_Min.Y) / 2.0));

						m_Min = m_Max = Point.Empty;
						int i = 0;
						for (; i < m_SortedTiles.Length; i++)
						{
							m_SortedTiles[i].m_OffsetX -= (short)centerx;
							m_SortedTiles[i].m_OffsetY -= (short)centery;
							if (m_SortedTiles[i].m_OffsetX < m_Min.X)
							{
								m_Min.X = m_SortedTiles[i].m_OffsetX;
							}
							if (m_SortedTiles[i].m_OffsetX > m_Max.X)
							{
								m_Max.X = m_SortedTiles[i].m_OffsetX;
							}

							if (m_SortedTiles[i].m_OffsetY < m_Min.Y)
							{
								m_Min.Y = m_SortedTiles[i].m_OffsetY;
							}
							if (m_SortedTiles[i].m_OffsetY > m_Max.Y)
							{
								m_Max.Y = m_SortedTiles[i].m_OffsetY;
							}
						}</pre>

Fragment 3 in file Ultima\Multis.cs

<pre>int centerx = m_Max.X - (int)(Math.Round((m_Max.X - m_Min.X) / 2.0));
			int centery = m_Max.Y - (int)(Math.Round((m_Max.Y - m_Min.Y) / 2.0));

			m_Min = m_Max = Point.Empty;
			int i = 0;
			for (; i < m_SortedTiles.Length; i++)
			{
				m_SortedTiles[i].m_OffsetX -= (short)centerx;
				m_SortedTiles[i].m_OffsetY -= (short)centery;
				if (m_SortedTiles[i].m_OffsetX < m_Min.X)
				{
					m_Min.X = m_SortedTiles[i].m_OffsetX;
				}
				if (m_SortedTiles[i].m_OffsetX > m_Max.X)
				{
					m_Max.X = m_SortedTiles[i].m_OffsetX;
				}

				if (m_SortedTiles[i].m_OffsetY < m_Min.Y)
				{
					m_Min.Y = m_SortedTiles[i].m_OffsetY;
				}
				if (m_SortedTiles[i].m_OffsetY > m_Max.Y)
				{
					m_Max.Y = m_SortedTiles[i].m_OffsetY;
				}
			}</pre>

## Duplicated Code. Size: 377

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>m_SortedTiles[itemcount].m_ItemID = Convert.ToUInt16(split[0]);
							m_SortedTiles[itemcount].m_OffsetX = Convert.ToInt16(split[1]);
							m_SortedTiles[itemcount].m_OffsetY = Convert.ToInt16(split[2]);
							m_SortedTiles[itemcount].m_OffsetZ = Convert.ToInt16(split[3]);
							m_SortedTiles[itemcount].m_Flags = Convert.ToInt32(split[4]);
							m_SortedTiles[itemcount].m_Unk1 = 0;

							MultiTileEntry e = m_SortedTiles[itemcount];

							if (e.m_OffsetX < m_Min.X)
							{
								m_Min.X = e.m_OffsetX;
							}

							if (e.m_OffsetY < m_Min.Y)
							{
								m_Min.Y = e.m_OffsetY;
							}

							if (e.m_OffsetX > m_Max.X)
							{
								m_Max.X = e.m_OffsetX;
							}

							if (e.m_OffsetY > m_Max.Y)
							{
								m_Max.Y = e.m_OffsetY;
							}

							if (e.m_OffsetZ > m_maxHeight)
							{
								m_maxHeight = e.m_OffsetZ;
							}

							++itemcount;</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>m_SortedTiles[itemcount].m_ItemID = Convert.ToUInt16(split[0]);
				m_SortedTiles[itemcount].m_Flags = Convert.ToInt32(split[1]);
				m_SortedTiles[itemcount].m_OffsetX = Convert.ToInt16(split[2]);
				m_SortedTiles[itemcount].m_OffsetY = Convert.ToInt16(split[3]);
				m_SortedTiles[itemcount].m_OffsetZ = Convert.ToInt16(split[4]);
				m_SortedTiles[itemcount].m_Unk1 = 0;

				MultiTileEntry e = m_SortedTiles[itemcount];

				if (e.m_OffsetX < m_Min.X)
				{
					m_Min.X = e.m_OffsetX;
				}
				if (e.m_OffsetY < m_Min.Y)
				{
					m_Min.Y = e.m_OffsetY;
				}
				if (e.m_OffsetX > m_Max.X)
				{
					m_Max.X = e.m_OffsetX;
				}
				if (e.m_OffsetY > m_Max.Y)
				{
					m_Max.Y = e.m_OffsetY;
				}
				if (e.m_OffsetZ > m_maxHeight)
				{
					m_maxHeight = e.m_OffsetZ;
				}

				++itemcount;</pre>

## Duplicated Code. Size: 292

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>for (int i = 0; i < 0x100; ++i)
			{
				bin.Write((ushort)(Palette[i] ^ 0x8000));
			}
			long startpos = (int)bin.BaseStream.Position;
			bin.Write(Frames.Count);
			long seek = (int)bin.BaseStream.Position;
			long curr = bin.BaseStream.Position + 4 * Frames.Count;
			foreach (FrameEdit frame in Frames)
			{
				bin.BaseStream.Seek(seek, SeekOrigin.Begin);
				bin.Write((int)(curr - startpos));
				seek = bin.BaseStream.Position;
				bin.BaseStream.Seek(curr, SeekOrigin.Begin);
				frame.Save(bin);
				curr = bin.BaseStream.Position;
			}</pre>

Fragment 2 in file Ultima\AnimationEdit.cs

<pre>for (int i = 0; i < 0x100; ++i)
			{
				bin.Write((ushort)(Palette[i] ^ 0x8000));
			}
			long startpos = bin.BaseStream.Position;
			bin.Write(Frames.Count);
			long seek = bin.BaseStream.Position;
			long curr = bin.BaseStream.Position + 4 * Frames.Count;
			foreach (FrameEdit frame in Frames)
			{
				bin.BaseStream.Seek(seek, SeekOrigin.Begin);
				bin.Write((int)(curr - startpos));
				seek = bin.BaseStream.Position;
				bin.BaseStream.Seek(curr, SeekOrigin.Begin);
				frame.Save(bin);
				curr = bin.BaseStream.Position;
			}</pre>

## Duplicated Code. Size: 265

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>var bmp = new Bitmap(0x100, 20, PixelFormat.Format16bppArgb1555);
						BitmapData bd = bmp.LockBits(
							new Rectangle(0, 0, 0x100, 20), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
						var line = (ushort*)bd.Scan0;
						int delta = bd.Stride >> 1;
						for (int y = 0; y < bd.Height; ++y, line += delta)
						{
							ushort* cur = line;
							for (int i = 0; i < 0x100; ++i)
							{
								*cur++ = Palette[i];
							}
						}
						bmp.UnlockBits(bd);
						var b = new Bitmap(bmp);</pre>

Fragment 2 in file Ultima\AnimationEdit.cs

<pre>var bmp = new Bitmap(0x100, 20, PixelFormat.Format16bppArgb1555);
						BitmapData bd = bmp.LockBits(
							new Rectangle(0, 0, 0x100, 20), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
						var line = (ushort*)bd.Scan0;
						int delta = bd.Stride >> 1;
						for (int y = 0; y < bd.Height; ++y, line += delta)
						{
							ushort* cur = line;
							for (int i = 0; i < 0x100; ++i)
							{
								*cur++ = Palette[i];
							}
						}
						bmp.UnlockBits(bd);
						var b = new Bitmap(bmp);</pre>

## Duplicated Code. Size: 239

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>{
							m_SortedTiles[i].m_OffsetX -= (short)centerx;
							m_SortedTiles[i].m_OffsetY -= (short)centery;
							if (m_SortedTiles[i].m_OffsetX < m_Min.X)
							{
								m_Min.X = m_SortedTiles[i].m_OffsetX;
							}
							if (m_SortedTiles[i].m_OffsetX > m_Max.X)
							{
								m_Max.X = m_SortedTiles[i].m_OffsetX;
							}

							if (m_SortedTiles[i].m_OffsetY < m_Min.Y)
							{
								m_Min.Y = m_SortedTiles[i].m_OffsetY;
							}
							if (m_SortedTiles[i].m_OffsetY > m_Max.Y)
							{
								m_Max.Y = m_SortedTiles[i].m_OffsetY;
							}
						}</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>{
				m_SortedTiles[i].m_OffsetX -= (short)centerx;
				m_SortedTiles[i].m_OffsetY -= (short)centery;
				if (m_SortedTiles[i].m_OffsetX < m_Min.X)
				{
					m_Min.X = m_SortedTiles[i].m_OffsetX;
				}
				if (m_SortedTiles[i].m_OffsetX > m_Max.X)
				{
					m_Max.X = m_SortedTiles[i].m_OffsetX;
				}

				if (m_SortedTiles[i].m_OffsetY < m_Min.Y)
				{
					m_Min.Y = m_SortedTiles[i].m_OffsetY;
				}
				if (m_SortedTiles[i].m_OffsetY > m_Max.Y)
				{
					m_Max.Y = m_SortedTiles[i].m_OffsetY;
				}
			}</pre>

## Duplicated Code. Size: 228

### Duplicated Fragments:

Fragment 1 in file Ultima\FileIndex.cs

<pre>if (String.IsNullOrEmpty(idxPath))
				{
					idxPath = null;
				}
				else
				{
					if (String.IsNullOrEmpty(Path.GetDirectoryName(idxPath)))
					{
						idxPath = Path.Combine(Files.RootDir, idxPath);
					}

					if (!File.Exists(idxPath))
					{
						idxPath = null;
					}
				}

				if (String.IsNullOrEmpty(MulPath))
				{
					MulPath = null;
				}
				else
				{
					if (String.IsNullOrEmpty(Path.GetDirectoryName(MulPath)))
					{
						MulPath = Path.Combine(Files.RootDir, MulPath);
					}

					if (!File.Exists(MulPath))
					{
						MulPath = null;
					}
				}</pre>

Fragment 2 in file Ultima\FileIndex.cs

<pre>if (String.IsNullOrEmpty(idxPath))
				{
					idxPath = null;
				}
				else
				{
					if (String.IsNullOrEmpty(Path.GetDirectoryName(idxPath)))
					{
						idxPath = Path.Combine(Files.RootDir, idxPath);
					}
					if (!File.Exists(idxPath))
					{
						idxPath = null;
					}
				}
				if (String.IsNullOrEmpty(MulPath))
				{
					MulPath = null;
				}
				else
				{
					if (String.IsNullOrEmpty(Path.GetDirectoryName(MulPath)))
					{
						MulPath = Path.Combine(Files.RootDir, MulPath);
					}
					if (!File.Exists(MulPath))
					{
						MulPath = null;
					}
				}</pre>

## Duplicated Code. Size: 214

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>{
						if (newtiles[i].m_OffsetX == 0 && newtiles[i].m_OffsetY == 0 && newtiles[i].m_ItemID != 0x1 &&
							newtiles[i].m_OffsetZ == 0)
						{
							MultiComponentList.MultiTileEntry centeritem = newtiles[i];
							newtiles.RemoveAt(i); // jep so save it
							for (int j = newtiles.Count - 1; j >= 0; --j) // and remove all invis
							{
								if (newtiles[j].m_ItemID == 0x1)
								{
									newtiles.RemoveAt(j);
								}
							}
							newtiles.Insert(0, centeritem);
							return newtiles;
						}
					}</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>{
				if (newtiles[i].m_OffsetX == 0 && newtiles[i].m_OffsetY == 0 && newtiles[i].m_ItemID != 0x1 &&
					newtiles[i].m_OffsetZ == 0)
				{
					MultiComponentList.MultiTileEntry centeritem = newtiles[i];
					newtiles.RemoveAt(i); // store it
					for (int j = newtiles.Count - 1; j >= 0; --j) // remove all invis
					{
						if (newtiles[j].m_ItemID == 0x1)
						{
							newtiles.RemoveAt(j);
						}
					}
					newtiles.Insert(0, centeritem);
					return newtiles;
				}
			}</pre>

## Duplicated Code. Size: 212

### Duplicated Fragments:

Fragment 1 in file Ultima\Map.cs

<pre>if (cache == null)
			{
				if (UseDiff)
				{
					if (statics)
					{
						m_Cache = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
				else
				{
					if (statics)
					{
						m_Cache_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
			}

			if (cache[y] == null)
			{
				cache[y] = new short[m_Tiles.BlockWidth][];
			}</pre>

Fragment 2 in file Ultima\Map.cs

<pre>if (cache == null)
			{
				if (UseDiff)
				{
					if (statics)
					{
						m_Cache = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
				else
				{
					if (statics)
					{
						m_Cache_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
					else
					{
						m_Cache_NoStatics_NoPatch = cache = new short[m_Tiles.BlockHeight][][];
					}
				}
			}

			if (cache[y] == null)
			{
				cache[y] = new short[m_Tiles.BlockWidth][];
			}</pre>

## Duplicated Code. Size: 201

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>for (int i = 0; i < 0x100; ++i)
				{
					Palette[i] = (ushort)(bin.ReadUInt16() ^ 0x8000);
				}

				var start = (int)bin.BaseStream.Position;
				int frameCount = bin.ReadInt32();

				var lookups = new int[frameCount];

				for (int i = 0; i < frameCount; ++i)
				{
					lookups[i] = start + bin.ReadInt32();
				}

				Frames = new List<FrameEdit>();</pre>

Fragment 2 in file Ultima\AnimationEdit.cs

<pre>for (int i = 0; i < 0x100; ++i)
			{
				Palette[i] = (ushort)(bin.ReadUInt16() ^ 0x8000);
			}

			var start = (int)bin.BaseStream.Position;
			int frameCount = bin.ReadInt32();

			var lookups = new int[frameCount];

			for (int i = 0; i < frameCount; ++i)
			{
				lookups[i] = start + bin.ReadInt32();
			}

			Frames = new List<FrameEdit>();</pre>

## Duplicated Code. Size: 198

### Duplicated Fragments:

Fragment 1 in file Ultima\Animations.cs

<pre>var palette = new ushort[0x100];

				for (int i = 0; i < 0x100; ++i)
				{
					palette[i] = (ushort)(bin.ReadUInt16() ^ 0x8000);
				}

				var start = (int)bin.BaseStream.Position;
				int frameCount = bin.ReadInt32();

				var lookups = new int[frameCount];

				for (int i = 0; i < frameCount; ++i)
				{
					lookups[i] = start + bin.ReadInt32();
				}</pre>

Fragment 2 in file Ultima\Animations.cs

<pre>var palette = new ushort[0x100];

				for (int i = 0; i < 0x100; ++i)
				{
					palette[i] = (ushort)(bin.ReadUInt16() ^ 0x8000);
				}

				var start = (int)bin.BaseStream.Position;
				int frameCount = bin.ReadInt32();

				var lookups = new int[frameCount];

				for (int i = 0; i < frameCount; ++i)
				{
					lookups[i] = start + bin.ReadInt32();
				}</pre>

## Duplicated Code. Size: 196

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>m_SortedTiles[itemcount].m_Unk1 = 0;

							MultiTileEntry e = m_SortedTiles[itemcount];

							if (e.m_OffsetX < m_Min.X)
							{
								m_Min.X = e.m_OffsetX;
							}

							if (e.m_OffsetY < m_Min.Y)
							{
								m_Min.Y = e.m_OffsetY;
							}

							if (e.m_OffsetX > m_Max.X)
							{
								m_Max.X = e.m_OffsetX;
							}

							if (e.m_OffsetY > m_Max.Y)
							{
								m_Max.Y = e.m_OffsetY;
							}

							if (e.m_OffsetZ > m_maxHeight)
							{
								m_maxHeight = e.m_OffsetZ;
							}</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>m_SortedTiles[itemcount].m_Unk1 = 0;

								MultiTileEntry e = m_SortedTiles[itemcount];

								if (e.m_OffsetX < m_Min.X)
								{
									m_Min.X = e.m_OffsetX;
								}

								if (e.m_OffsetY < m_Min.Y)
								{
									m_Min.Y = e.m_OffsetY;
								}

								if (e.m_OffsetX > m_Max.X)
								{
									m_Max.X = e.m_OffsetX;
								}

								if (e.m_OffsetY > m_Max.Y)
								{
									m_Max.Y = e.m_OffsetY;
								}

								if (e.m_OffsetZ > m_maxHeight)
								{
									m_maxHeight = e.m_OffsetZ;
								}</pre>

## Duplicated Code. Size: 195

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>if (m_patched.Contains(index))
			{
				patched = (bool)m_patched[index];
			}
			else
			{
				patched = false;
			}

			if (m_Removed[index])
			{
				return null;
			}
			if (m_Cache[index] != null)
			{
				return m_Cache[index];
			}

			int length, extra;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}
			if (patched)
			{
				m_patched[index] = true;
			}</pre>

Fragment 2 in file Ultima\Art.cs

<pre>if (m_patched.Contains(index))
			{
				patched = (bool)m_patched[index];
			}
			else
			{
				patched = false;
			}

			if (m_Removed[index])
			{
				return null;
			}
			if (m_Cache[index] != null)
			{
				return m_Cache[index];
			}

			int length, extra;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}
			if (patched)
			{
				m_patched[index] = true;
			}</pre>

## Duplicated Code. Size: 173

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>int BlueTemp = (Palette[i] - 0x8000) / 0x20;
				BlueTemp *= 0x20;
				BlueTemp = (Palette[i] - 0x8000) - BlueTemp;
				int GreenTemp = (Palette[i] - 0x8000) / 0x400;
				GreenTemp *= 0x400;
				GreenTemp = ((Palette[i] - 0x8000) - GreenTemp) - BlueTemp;
				GreenTemp /= 0x20;
				int RedTemp = (Palette[i] - 0x8000) / 0x400;</pre>

Fragment 2 in file Ultima\AnimationEdit.cs

<pre>int BlueTemp = (Palette[i] - 0x8000) / 0x20;
				BlueTemp *= 0x20;
				BlueTemp = (Palette[i] - 0x8000) - BlueTemp;
				int GreenTemp = (Palette[i] - 0x8000) / 0x400;
				GreenTemp *= 0x400;
				GreenTemp = ((Palette[i] - 0x8000) - GreenTemp) - BlueTemp;
				GreenTemp /= 0x20;
				int RedTemp = (Palette[i] - 0x8000) / 0x400;</pre>

## Duplicated Code. Size: 151

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>BitmapData bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							int delta = bd.Stride >> 1;
							binidx.Write((int)binmul.BaseStream.Position); //lookup
							var length = (int)binmul.BaseStream.Position;</pre>

Fragment 2 in file Ultima\Art.cs

<pre>BitmapData bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							int delta = bd.Stride >> 1;
							binidx.Write((int)binmul.BaseStream.Position); //lookup
							var length = (int)binmul.BaseStream.Position;</pre>

Fragment 3 in file Ultima\Textures.cs

<pre>BitmapData bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							int delta = bd.Stride >> 1;

							binidx.Write((int)binmul.BaseStream.Position); //lookup
							var length = (int)binmul.BaseStream.Position;</pre>

## Duplicated Code. Size: 148

### Duplicated Fragments:

Fragment 1 in file Ultima\Gumps.cs

<pre>var bmp = new Bitmap(width, height, PixelFormat.Format16bppArgb1555);
			BitmapData bd = bmp.LockBits(
				new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);

			if (m_StreamBuffer == null || m_StreamBuffer.Length < length)
			{
				m_StreamBuffer = new byte[length];
			}
			stream.Read(m_StreamBuffer, 0, length);</pre>

Fragment 2 in file Ultima\Light.cs

<pre>if (m_StreamBuffer == null || m_StreamBuffer.Length < length)
			{
				m_StreamBuffer = new byte[length];
			}
			stream.Read(m_StreamBuffer, 0, length);

			var bmp = new Bitmap(width, height, PixelFormat.Format16bppArgb1555);
			BitmapData bd = bmp.LockBits(
				new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);</pre>

## Duplicated Code. Size: 145

### Duplicated Fragments:

Fragment 1 in file Ultima\Gumps.cs

<pre>BitmapData bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							int delta = bd.Stride >> 1;

							binidx.Write((int)fsmul.Position); //lookup
							var length = (int)fsmul.Position;</pre>

Fragment 2 in file Ultima\Light.cs

<pre>BitmapData bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							int delta = bd.Stride >> 1;

							binidx.Write((int)fsmul.Position); //lookup
							var length = (int)fsmul.Position;</pre>

## Duplicated Code. Size: 143

### Duplicated Fragments:

Fragment 1 in file Ultima\RadarCol.cs

<pre>private static int ConvertStringToInt(string text)
		{
			int result;
			if (text.Contains("0x"))
			{
				string convert = text.Replace("0x", "");
				int.TryParse(convert, NumberStyles.HexNumber, null, out result);
			}
			else
			{
				int.TryParse(text, NumberStyles.Integer, null, out result);
			}

			return result;
		}</pre>

Fragment 2 in file Ultima\SpeechList.cs

<pre>public static int ConvertStringToInt(string text)
		{
			int result;
			if (text.Contains("0x"))
			{
				string convert = text.Replace("0x", "");
				int.TryParse(convert, NumberStyles.HexNumber, null, out result);
			}
			else
			{
				int.TryParse(text, NumberStyles.Integer, null, out result);
			}

			return result;
		}</pre>

Fragment 3 in file Ultima\TileData.cs

<pre>public static int ConvertStringToInt(string text)
		{
			int result;
			if (text.Contains("0x"))
			{
				string convert = text.Replace("0x", "");
				int.TryParse(convert, NumberStyles.HexNumber, null, out result);
			}
			else
			{
				int.TryParse(text, NumberStyles.Integer, null, out result);
			}

			return result;
		}</pre>

## Duplicated Code. Size: 136

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>if (((cmp == null) || (newchecksum == null)) || (cmp.Length != newchecksum.Length))
				{
					return false;
				}
				bool valid = true;
				for (int j = 0; j < cmp.Length; ++j)
				{
					if (cmp[j] != newchecksum[j])
					{
						valid = false;
						break;
					}
				}</pre>

Fragment 2 in file Ultima\Art.cs

<pre>if (((cmp == null) || (newchecksum == null)) || (cmp.Length != newchecksum.Length))
				{
					return false;
				}
				bool valid = true;
				for (int j = 0; j < cmp.Length; ++j)
				{
					if (cmp[j] != newchecksum[j])
					{
						valid = false;
						break;
					}
				}</pre>

Fragment 3 in file Ultima\Textures.cs

<pre>if (((cmp == null) || (newchecksum == null)) || (cmp.Length != newchecksum.Length))
				{
					return false;
				}
				bool valid = true;
				for (int j = 0; j < cmp.Length; ++j)
				{
					if (cmp[j] != newchecksum[j])
					{
						valid = false;
						break;
					}
				}</pre>

## Duplicated Code. Size: 129

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>int length, extra;
			bool patched;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}
			var buffer = new byte[length];
			stream.Read(buffer, 0, length);
			stream.Close();
			return buffer;</pre>

Fragment 2 in file Ultima\Art.cs

<pre>int length, extra;
			bool patched;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}
			var buffer = new byte[length];
			stream.Read(buffer, 0, length);
			stream.Close();
			return buffer;</pre>

## Duplicated Code. Size: 127

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>var bmp = new Bitmap(width, height, PixelFormat.Format16bppArgb1555);
				BitmapData bd = bmp.LockBits(
					new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
				var line = (ushort*)bd.Scan0;
				int delta = bd.Stride >> 1;</pre>

Fragment 2 in file Ultima\Animations.cs

<pre>var bmp = new Bitmap(width, height, PixelFormat.Format16bppArgb1555);
			BitmapData bd = bmp.LockBits(
				new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
			var line = (ushort*)bd.Scan0;
			int delta = bd.Stride >> 1;</pre>

## Duplicated Code. Size: 125

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>int centerx = m_Max.X - (int)(Math.Round((m_Max.X - m_Min.X) / 2.0));
						int centery = m_Max.Y - (int)(Math.Round((m_Max.Y - m_Min.Y) / 2.0));

						m_Min = m_Max = Point.Empty;</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>int centerx = m_Max.X - (int)(Math.Round((m_Max.X - m_Min.X) / 2.0));
							int centery = m_Max.Y - (int)(Math.Round((m_Max.Y - m_Min.Y) / 2.0));

							m_Min = m_Max = Point.Empty;</pre>

Fragment 3 in file Ultima\Multis.cs

<pre>int centerx = m_Max.X - (int)(Math.Round((m_Max.X - m_Min.X) / 2.0));
			int centery = m_Max.Y - (int)(Math.Round((m_Max.Y - m_Min.Y) / 2.0));

			m_Min = m_Max = Point.Empty;</pre>

## Duplicated Code. Size: 123

### Duplicated Fragments:

Fragment 1 in file Ultima\Animations.cs

<pre>FileIndex fileIndex;
			int index;
			GetFileIndex(body, action, direction, fileType, out fileIndex, out index);

			int length, extra;
			bool patched;
			Stream stream = fileIndex.Seek(index, out length, out extra, out patched);

			if (stream == null)
			{
				return null;
			}</pre>

Fragment 2 in file Ultima\Animations.cs

<pre>FileIndex fileIndex;
			int index;
			GetFileIndex(body, action, direction, fileType, out fileIndex, out index);

			int length, extra;
			bool patched;

			Stream stream = fileIndex.Seek(index, out length, out extra, out patched);

			if (stream == null)
			{
				return null;
			}</pre>

## Duplicated Code. Size: 121

### Duplicated Fragments:

Fragment 1 in file Ultima\TileData.cs

<pre>m_Weight = mulstruct.weight;
			m_Quality = mulstruct.quality;
			m_Quantity = mulstruct.quantity;
			m_Value = mulstruct.value;
			m_Height = mulstruct.height;
			m_Animation = mulstruct.anim;
			m_Hue = mulstruct.hue;
			m_StackOffset = mulstruct.stackingoffset;
			m_MiscData = mulstruct.miscdata;
			m_Unk2 = mulstruct.unk2;
			m_Unk3 = mulstruct.unk3;</pre>

Fragment 2 in file Ultima\TileData.cs

<pre>m_Weight = mulstruct.weight;
			m_Quality = mulstruct.quality;
			m_Quantity = mulstruct.quantity;
			m_Value = mulstruct.value;
			m_Height = mulstruct.height;
			m_Animation = mulstruct.anim;
			m_Hue = mulstruct.hue;
			m_StackOffset = mulstruct.stackingoffset;
			m_MiscData = mulstruct.miscdata;
			m_Unk2 = mulstruct.unk2;
			m_Unk3 = mulstruct.unk3;</pre>

## Duplicated Code. Size: 120

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>if (m_Removed[index])
			{
				return false;
			}
			if (m_Cache[index] != null)
			{
				return true;
			}

			int length, extra;
			bool patched;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);

			if (stream == null)
			{
				return false;
			}</pre>

Fragment 2 in file Ultima\Light.cs

<pre>if (m_Removed[index])
			{
				return false;
			}
			if (m_Cache[index] != null)
			{
				return true;
			}

			int length, extra;
			bool patched;

			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);

			if (stream == null)
			{
				return false;
			}</pre>

## Duplicated Code. Size: 119

### Duplicated Fragments:

Fragment 1 in file Ultima\Gumps.cs

<pre>if (m_Removed[index])
			{
				return null;
			}
			if (m_Cache[index] != null)
			{
				return m_Cache[index];
			}
			int length, extra;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}</pre>

Fragment 2 in file Ultima\Textures.cs

<pre>if (m_Removed[index])
			{
				return null;
			}
			if (m_Cache[index] != null)
			{
				return m_Cache[index];
			}

			int length, extra;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}</pre>

## Duplicated Code. Size: 117

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>int start = length;
							length = (int)binmul.BaseStream.Position - length;
							binidx.Write(length);
							binidx.Write(0);
							bmp.UnlockBits(bd);
							var s = new CheckSums
							{
								pos = start,
								length = length,
								checksum = checksum,
								index = index
							};</pre>

Fragment 2 in file Ultima\Art.cs

<pre>int start = length;
							length = (int)binmul.BaseStream.Position - length;
							binidx.Write(length);
							binidx.Write(0);
							bmp.UnlockBits(bd);
							var s = new CheckSums
							{
								pos = start,
								length = length,
								checksum = checksum,
								index = index
							};</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>BitmapData bd = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppArgb1555);
			var line = (ushort*)bd.Scan0;
			int delta = bd.Stride >> 1;</pre>

Fragment 2 in file Ultima\ASCIIFont.cs

<pre>BitmapData bd = bmp.LockBits(
								new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format16bppArgb1555);
							var line = (ushort*)bd.Scan0;
							int delta = bd.Stride >> 1;</pre>

## Duplicated Code. Size: 103

### Duplicated Fragments:

Fragment 1 in file Ultima\ASCIIFont.cs

<pre>BitmapData bd = bmp.LockBits(
										new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
									var line = (ushort*)bd.Scan0;
									int delta = bd.Stride >> 1;</pre>

Fragment 2 in file Ultima\MultiMap.cs

<pre>BitmapData bd = bmp.LockBits(
						new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
					var line = (ushort*)bd.Scan0;
					int delta = bd.Stride >> 1;</pre>

Fragment 3 in file Ultima\UnicodeFont.cs

<pre>BitmapData bd = bmp.LockBits(
				new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format16bppArgb1555);
			var line = (ushort*)bd.Scan0;
			int delta = bd.Stride >> 1;</pre>

## Duplicated Code. Size: 97

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>int px = (x - y) * 22;
						int py = (x + y) * 22;

						px -= (bmp.Width / 2);
						py -= tiles[i].Z << 2;
						py -= bmp.Height;</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>int px = (x - y) * 22;
						int py = (x + y) * 22;

						px -= (bmp.Width / 2);
						py -= tiles[i].Z << 2;
						py -= bmp.Height;</pre>

## Duplicated Code. Size: 96

### Duplicated Fragments:

Fragment 1 in file Ultima\Map.cs

<pre>binmul.Write(tilelist[i].m_ID);
													binmul.Write(tilelist[i].m_X);
													binmul.Write(tilelist[i].m_Y);
													binmul.Write(tilelist[i].m_Z);</pre>

Fragment 2 in file Ultima\Map.cs

<pre>binmul.Write(tilelist[i].m_ID);
												binmul.Write(tilelist[i].m_X);
												binmul.Write(tilelist[i].m_Y);
												binmul.Write(tilelist[i].m_Z);</pre>

## Duplicated Code. Size: 92

### Duplicated Fragments:

Fragment 1 in file Ultima\StringList.cs

<pre>if (objA.Number == objB.Number)
				{
					return 0;
				}
				else if (m_desc)
				{
					return (objA.Number < objB.Number) ? 1 : -1;
				}
				else
				{
					return (objA.Number < objB.Number) ? -1 : 1;
				}</pre>

Fragment 2 in file Ultima\StringList.cs

<pre>if (objA.Number == objB.Number)
					{
						return 0;
					}
					else if (m_desc)
					{
						return (objA.Number < objB.Number) ? 1 : -1;
					}
					else
					{
						return (objA.Number < objB.Number) ? -1 : 1;
					}</pre>

## Duplicated Code. Size: 91

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>int length, extra;
			bool patched;
			bool valid = fileIndex.Valid(index, out length, out extra, out patched);
			if ((!valid) || (length < 1))
			{
				return false;
			}
			return true;</pre>

Fragment 2 in file Ultima\Animations.cs

<pre>int length, extra;
			bool patched;
			bool valid = fileIndex.Valid(index, out length, out extra, out patched);
			if ((!valid) || (length < 1))
			{
				return false;
			}
			return true;</pre>

## Duplicated Code. Size: 87

### Duplicated Fragments:

Fragment 1 in file Ultima\StringEntry.cs

<pre>for (int i = 0; i < args.Length && i < 10; i++)
			{
				m_Args[i + 1] = args[i];
			}
			return String.Format(m_FmtTxt, m_Args);</pre>

Fragment 2 in file Ultima\StringEntry.cs

<pre>for (int i = 0; i < args.Length && i < 10; i++)
			{
				m_Args[i + 1] = args[i];
			}
			return String.Format(m_FmtTxt, m_Args);</pre>

## Duplicated Code. Size: 86

### Duplicated Fragments:

Fragment 1 in file Ultima\FileIndex.cs

<pre>{
						Index[patch.index].lookup = patch.lookup;
						Index[patch.index].length = patch.length | (1 << 31);
						Index[patch.index].extra = patch.extra;
					}</pre>

Fragment 2 in file Ultima\FileIndex.cs

<pre>{
						Index[patch.index].lookup = patch.lookup;
						Index[patch.index].length = patch.length | (1 << 31);
						Index[patch.index].extra = patch.extra;
					}</pre>

## Duplicated Code. Size: 86

### Duplicated Fragments:

Fragment 1 in file Ultima\Skills.cs

<pre>for (int i = 0; i < m_FileIndex.Index.Length; ++i)
					{
						SkillInfo info = GetSkill(i);
						if (info == null)
						{
							break;
						}
						m_SkillEntries.Add(info);
					}</pre>

Fragment 2 in file Ultima\Skills.cs

<pre>for (int i = 0; i < m_FileIndex.Index.Length; ++i)
			{
				SkillInfo info = GetSkill(i);
				if (info == null)
				{
					break;
				}
				m_SkillEntries.Add(info);
			}</pre>

## Duplicated Code. Size: 81

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>{
					ushort* cur = line + xOffset;
					ushort* end = cur + xRun;

					while (cur < end)
					{
						*cur++ = (ushort)(*bdata++ | 0x8000);
					}
				}</pre>

Fragment 2 in file Ultima\Art.cs

<pre>{
					ushort* cur = line + xOffset;
					ushort* end = cur + xRun;

					while (cur < end)
					{
						*cur++ = (ushort)(*bdata++ | 0x8000);
					}
				}</pre>

## Duplicated Code. Size: 80

### Duplicated Fragments:

Fragment 1 in file Ultima\FileIndex.cs

<pre>GCHandle gc = GCHandle.Alloc(Index, GCHandleType.Pinned);
					var buffer = new byte[index.Length];
					index.Read(buffer, 0, (int)index.Length);</pre>

Fragment 2 in file Ultima\FileIndex.cs

<pre>GCHandle gc = GCHandle.Alloc(Index, GCHandleType.Pinned);
					var buffer = new byte[index.Length];
					index.Read(buffer, 0, (int)index.Length);</pre>

## Duplicated Code. Size: 80

### Duplicated Fragments:

Fragment 1 in file Ultima\Gumps.cs

<pre>length = (int)fsmul.Position - length;
							binidx.Write(length);
							binidx.Write((bmp.Width << 16) + bmp.Height);
							bmp.UnlockBits(bd);</pre>

Fragment 2 in file Ultima\Light.cs

<pre>length = (int)fsmul.Position - length;
							binidx.Write(length);
							binidx.Write((bmp.Width << 16) + bmp.Height);
							bmp.UnlockBits(bd);</pre>

## Duplicated Code. Size: 80

### Duplicated Fragments:

Fragment 1 in file Ultima\TileMatrix.cs

<pre>public Tile GetLandTile(int x, int y)
		{
			return GetLandBlock(x >> 3, y >> 3)[((y & 0x7) << 3) + (x & 0x7)];
		}</pre>

Fragment 2 in file Ultima\TileMatrixPatch.cs

<pre>public Tile GetLandTile(int x, int y)
		{
			return GetLandBlock(x >> 3, y >> 3)[((y & 0x7) << 3) + (x & 0x7)];
		}</pre>

## Duplicated Code. Size: 78

### Duplicated Fragments:

Fragment 1 in file Ultima\Client.cs

<pre>pc.Seek(0x400000 + (i * chunkSize), SeekOrigin.Begin);
				int count = pc.Read(read, 0, readSize);

				if (count != readSize)
				{
					break;
				}</pre>

Fragment 2 in file Ultima\Client.cs

<pre>pc.Seek(0x400000 + (i * chunkSize), SeekOrigin.Begin);
				int count = pc.Read(read, 0, readSize);

				if (count != readSize)
				{
					break;
				}</pre>

## Duplicated Code. Size: 77

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>var ms = new MemoryStream();
							bmp.Save(ms, ImageFormat.Bmp);
							byte[] checksum = sha.ComputeHash(ms.ToArray());
							CheckSums sum;</pre>

Fragment 2 in file Ultima\Art.cs

<pre>var ms = new MemoryStream();
							bmp.Save(ms, ImageFormat.Bmp);
							byte[] checksum = sha.ComputeHash(ms.ToArray());
							CheckSums sum;</pre>

Fragment 3 in file Ultima\Textures.cs

<pre>var ms = new MemoryStream();
							bmp.Save(ms, ImageFormat.Bmp);
							byte[] checksum = sha.ComputeHash(ms.ToArray());
							CheckSums sum;</pre>

## Duplicated Code. Size: 77

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 2 in file Ultima\Art.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 3 in file Ultima\Gumps.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 4 in file Ultima\Light.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 5 in file Ultima\Map.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 6 in file Ultima\Multis.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 7 in file Ultima\Skills.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 8 in file Ultima\Sound.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

Fragment 9 in file Ultima\Textures.cs

<pre>FileStream fsidx = new FileStream(idx, FileMode.Create, FileAccess.Write, FileShare.Write),
						   fsmul = new FileStream(mul, FileMode.Create, FileAccess.Write, FileShare.Write)</pre>

## Duplicated Code. Size: 75

### Duplicated Fragments:

Fragment 1 in file Ultima\FileIndex.cs

<pre>Stream = new FileStream(MulPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
					var count = (int)(index.Length / 12);
					IdxLength = index.Length;</pre>

Fragment 2 in file Ultima\FileIndex.cs

<pre>Stream = new FileStream(MulPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
					var count = (int)(index.Length / 12);
					IdxLength = index.Length;</pre>

## Duplicated Code. Size: 75

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>index = binbin.ReadInt32();
											x = binbin.ReadInt32();
											y = binbin.ReadInt32();
											z = binbin.ReadInt32();
											level = binbin.ReadInt32();</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>index = binbin.ReadInt32();
											x = binbin.ReadInt32();
											y = binbin.ReadInt32();
											z = binbin.ReadInt32();
											level = binbin.ReadInt32();</pre>

## Duplicated Code. Size: 75

### Duplicated Fragments:

Fragment 1 in file Ultima\Multis.cs

<pre>for (int j = newtiles.Count - 1; j >= 0; --j) // remove all invis items
					{
						if (newtiles[j].m_ItemID == 0x1)
						{
							newtiles.RemoveAt(j);
						}
					}</pre>

Fragment 2 in file Ultima\Multis.cs

<pre>for (int j = newtiles.Count - 1; j >= 0; --j) // nothing found so remove all invis
			{
				if (newtiles[j].m_ItemID == 0x1)
				{
					newtiles.RemoveAt(j);
				}
			}</pre>

## Duplicated Code. Size: 75

### Duplicated Fragments:

Fragment 1 in file Ultima\TileMatrix.cs

<pre>{
			if (m_Map != null)
			{
				m_Map.Close();
			}

			if (m_UOPReader != null)
			{
				m_UOPReader.Close();
			}

			if (m_Statics != null)
			{
				m_Statics.Close();
			}
		}</pre>

Fragment 2 in file Ultima\TileMatrix.cs

<pre>{
			if (m_Map != null)
			{
				m_Map.Close();
			}

			if (m_UOPReader != null)
			{
				m_UOPReader.Close();
			}

			if (m_Statics != null)
			{
				m_Statics.Close();
			}
		}</pre>

## Duplicated Code. Size: 74

### Duplicated Fragments:

Fragment 1 in file Ultima\Gumps.cs

<pre>int length, extra;
			bool patched;
			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}</pre>

Fragment 2 in file Ultima\Light.cs

<pre>int length, extra;
			bool patched;

			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);

			if (stream == null)
			{
				return null;
			}</pre>

Fragment 3 in file Ultima\Light.cs

<pre>int length, extra;
			bool patched;

			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);

			if (stream == null)
			{
				return null;
			}</pre>

Fragment 4 in file Ultima\Skills.cs

<pre>int length, extra;
			bool patched;

			Stream stream = m_FileIndex.Seek(index, out length, out extra, out patched);
			if (stream == null)
			{
				return null;
			}</pre>

## Duplicated Code. Size: 73

### Duplicated Fragments:

Fragment 1 in file Ultima\TileMatrix.cs

<pre>public HuedTile[] GetStaticTiles(int x, int y)
		{
			return GetStaticBlock(x >> 3, y >> 3)[x & 0x7][y & 0x7];
		}</pre>

Fragment 2 in file Ultima\TileMatrixPatch.cs

<pre>public HuedTile[] GetStaticTiles(int x, int y)
		{
			return GetStaticBlock(x >> 3, y >> 3)[x & 0x7][y & 0x7];
		}</pre>

## Duplicated Code. Size: 72

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>if (m_StreamBuffer == null || m_StreamBuffer.Length < length)
			{
				m_StreamBuffer = new byte[length];
			}
			stream.Read(m_StreamBuffer, 0, length);
			stream.Close();</pre>

Fragment 2 in file Ultima\Art.cs

<pre>if (m_StreamBuffer == null || m_StreamBuffer.Length < length)
			{
				m_StreamBuffer = new byte[length];
			}
			stream.Read(m_StreamBuffer, 0, length);
			stream.Close();</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Ultima\AnimationEdit.cs

<pre>AnimIdx[] cache = GetCache(filetype);
			FileIndex fileIndex;
			int index;
			GetFileIndex(body, filetype, 0, 0, out fileIndex, out index);</pre>

Fragment 2 in file Ultima\AnimationEdit.cs

<pre>AnimIdx[] cache = GetCache(filetype);
			FileIndex fileIndex;
			int index;
			GetFileIndex(body, filetype, 0, 0, out fileIndex, out index);</pre>

## Duplicated Code. Size: 71

### Duplicated Fragments:

Fragment 1 in file Ultima\Art.cs

<pre>m_Cache[index] = bmp;
			m_Removed[index] = false;
			if (m_patched.Contains(index))
			{
				m_patched.Remove(index);
			}
			Modified = true;</pre>

Fragment 2 in file Ultima\Art.cs

<pre>m_Cache[index] = bmp;
			m_Removed[index] = false;
			if (m_patched.Contains(index))
			{
				m_patched.Remove(index);
			}
			Modified = true;</pre>