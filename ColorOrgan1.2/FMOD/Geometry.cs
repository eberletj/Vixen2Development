using System;
using System.Runtime.InteropServices;
namespace FMOD
{
	public class Geometry
	{
		public class Reverb
		{
			private IntPtr reverbraw;
			public RESULT release()
			{
				return Geometry.Reverb.FMOD_Reverb_Release(reverbraw);
			}
			public RESULT set3DAttributes(ref VECTOR position, float mindistance, float maxdistance)
			{
				return Geometry.Reverb.FMOD_Reverb_Set3DAttributes(reverbraw, ref position, mindistance, maxdistance);
			}
			public RESULT get3DAttributes(ref VECTOR position, ref float mindistance, ref float maxdistance)
			{
				return Geometry.Reverb.FMOD_Reverb_Get3DAttributes(reverbraw, ref position, ref mindistance, ref maxdistance);
			}
			public RESULT setProperties(ref REVERB_PROPERTIES properties)
			{
				return Geometry.Reverb.FMOD_Reverb_SetProperties(reverbraw, ref properties);
			}
			public RESULT getProperties(ref REVERB_PROPERTIES properties)
			{
				return Geometry.Reverb.FMOD_Reverb_GetProperties(reverbraw, ref properties);
			}
			public RESULT setActive(int active)
			{
				return Geometry.Reverb.FMOD_Reverb_SetActive(reverbraw, active);
			}
			public RESULT getActive(ref int active)
			{
				return Geometry.Reverb.FMOD_Reverb_GetActive(reverbraw, ref active);
			}
			public RESULT setUserData(IntPtr userdata)
			{
				return Geometry.Reverb.FMOD_Reverb_SetUserData(reverbraw, userdata);
			}
			public RESULT getUserData(ref IntPtr userdata)
			{
				return Geometry.Reverb.FMOD_Reverb_GetUserData(reverbraw, ref userdata);
			}
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_Release(IntPtr reverb);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_Set3DAttributes(IntPtr reverb, ref VECTOR position, float mindistance, float maxdistance);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_Get3DAttributes(IntPtr reverb, ref VECTOR position, ref float mindistance, ref float maxdistance);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_SetProperties(IntPtr reverb, ref REVERB_PROPERTIES properties);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_GetProperties(IntPtr reverb, ref REVERB_PROPERTIES properties);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_SetActive(IntPtr reverb, int active);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_GetActive(IntPtr reverb, ref int active);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_SetUserData(IntPtr reverb, IntPtr userdata);
			[DllImport("fmodex")]
			private static extern RESULT FMOD_Reverb_GetUserData(IntPtr reverb, ref IntPtr userdata);
			public void setRaw(IntPtr rev)
			{
				reverbraw = IntPtr.Zero;
				reverbraw = rev;
			}
			public IntPtr getRaw()
			{
				return reverbraw;
			}
		}
		private IntPtr geometryraw;
		public RESULT release()
		{
			return Geometry.FMOD_Geometry_Release(geometryraw);
		}
		public RESULT addPolygon(float directOcclusion, float reverbOcclusion, bool doubleSided, int numVertices, ref VECTOR vertices, ref int polygonIndex)
		{
			return Geometry.FMOD_Geometry_AddPolygon(geometryraw, directOcclusion, reverbOcclusion, doubleSided, numVertices, ref vertices, ref polygonIndex);
		}
		public RESULT getNumPolygons(ref int numPolygons)
		{
			return Geometry.FMOD_Geometry_GetNumPolygons(geometryraw, ref numPolygons);
		}
		public RESULT getMaxPolygons(ref int maxPolygons, ref int maxVertices)
		{
			return Geometry.FMOD_Geometry_GetMaxPolygons(geometryraw, ref maxPolygons, ref maxVertices);
		}
		public RESULT getPolygonNumVertices(int polygonIndex, ref int numVertices)
		{
			return Geometry.FMOD_Geometry_GetPolygonNumVertices(geometryraw, polygonIndex, ref numVertices);
		}
		public RESULT setPolygonVertex(int polygonIndex, int vertexIndex, ref VECTOR vertex)
		{
			return Geometry.FMOD_Geometry_SetPolygonVertex(geometryraw, polygonIndex, vertexIndex, ref vertex);
		}
		public RESULT getPolygonVertex(int polygonIndex, int vertexIndex, ref VECTOR vertex)
		{
			return Geometry.FMOD_Geometry_GetPolygonVertex(geometryraw, polygonIndex, vertexIndex, ref vertex);
		}
		public RESULT setPolygonAttributes(int polygonIndex, float directOcclusion, float reverbOcclusion, bool doubleSided)
		{
			return Geometry.FMOD_Geometry_SetPolygonAttributes(geometryraw, polygonIndex, directOcclusion, reverbOcclusion, doubleSided);
		}
		public RESULT getPolygonAttributes(int polygonIndex, ref float directOcclusion, ref float reverbOcclusion, ref bool doubleSided)
		{
			return Geometry.FMOD_Geometry_GetPolygonAttributes(geometryraw, polygonIndex, ref directOcclusion, ref reverbOcclusion, ref doubleSided);
		}
		public RESULT setActive(bool active)
		{
			return Geometry.FMOD_Geometry_SetActive(geometryraw, active);
		}
		public RESULT getActive(ref bool active)
		{
			return Geometry.FMOD_Geometry_GetActive(geometryraw, ref active);
		}
		public RESULT setRotation(ref VECTOR forward, ref VECTOR up)
		{
			return Geometry.FMOD_Geometry_SetRotation(geometryraw, ref forward, ref up);
		}
		public RESULT getRotation(ref VECTOR forward, ref VECTOR up)
		{
			return Geometry.FMOD_Geometry_GetRotation(geometryraw, ref forward, ref up);
		}
		public RESULT setPosition(ref VECTOR position)
		{
			return Geometry.FMOD_Geometry_SetPosition(geometryraw, ref position);
		}
		public RESULT getPosition(ref VECTOR position)
		{
			return Geometry.FMOD_Geometry_GetPosition(geometryraw, ref position);
		}
		public RESULT setScale(ref VECTOR scale)
		{
			return Geometry.FMOD_Geometry_SetScale(geometryraw, ref scale);
		}
		public RESULT getScale(ref VECTOR scale)
		{
			return Geometry.FMOD_Geometry_GetScale(geometryraw, ref scale);
		}
		public RESULT save(IntPtr data, ref int datasize)
		{
			return Geometry.FMOD_Geometry_Save(geometryraw, data, ref datasize);
		}
		public RESULT setUserData(IntPtr userdata)
		{
			return Geometry.FMOD_Geometry_SetUserData(geometryraw, userdata);
		}
		public RESULT getUserData(ref IntPtr userdata)
		{
			return Geometry.FMOD_Geometry_GetUserData(geometryraw, ref userdata);
		}
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_Release(IntPtr geometry);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_AddPolygon(IntPtr geometry, float directOcclusion, float reverbOcclusion, bool doubleSided, int numVertices, ref VECTOR vertices, ref int polygonIndex);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetNumPolygons(IntPtr geometry, ref int numPolygons);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetMaxPolygons(IntPtr geometry, ref int maxPolygons, ref int maxVertices);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetPolygonNumVertices(IntPtr geometry, int polygonIndex, ref int numVertices);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_SetPolygonVertex(IntPtr geometry, int polygonIndex, int vertexIndex, ref VECTOR vertex);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetPolygonVertex(IntPtr geometry, int polygonIndex, int vertexIndex, ref VECTOR vertex);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_SetPolygonAttributes(IntPtr geometry, int polygonIndex, float directOcclusion, float reverbOcclusion, bool doubleSided);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetPolygonAttributes(IntPtr geometry, int polygonIndex, ref float directOcclusion, ref float reverbOcclusion, ref bool doubleSided);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_Flush(IntPtr geometry);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_SetActive(IntPtr gemoetry, bool active);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetActive(IntPtr gemoetry, ref bool active);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_SetRotation(IntPtr geometry, ref VECTOR forward, ref VECTOR up);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetRotation(IntPtr geometry, ref VECTOR forward, ref VECTOR up);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_SetPosition(IntPtr geometry, ref VECTOR position);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetPosition(IntPtr geometry, ref VECTOR position);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_SetScale(IntPtr geometry, ref VECTOR scale);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetScale(IntPtr geometry, ref VECTOR scale);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_Save(IntPtr geometry, IntPtr data, ref int datasize);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_SetUserData(IntPtr geometry, IntPtr userdata);
		[DllImport("fmodex")]
		private static extern RESULT FMOD_Geometry_GetUserData(IntPtr geometry, ref IntPtr userdata);
		public void setRaw(IntPtr geometry)
		{
			geometryraw = IntPtr.Zero;
			geometryraw = geometry;
		}
		public IntPtr getRaw()
		{
			return geometryraw;
		}
	}
}
