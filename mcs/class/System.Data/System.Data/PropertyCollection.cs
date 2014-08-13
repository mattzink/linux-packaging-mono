//
// System.Data.PropertyCollection.cs
//
// Author:
//    Daniel Morgan <danmorg@sc.rr.com>
//
// (c) Ximian, Inc. 2002
//

//
// Copyright (C) 2004 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.ComponentModel;

namespace System.Data
{
	/// <summary>
	/// a collection of properties that can be added to 
	/// DataColumn, DataSet, or DataTable.
	/// The ExtendedProperties property of a 
	/// DataColumn, DataSet, or DataTable class can
	/// retrieve a PropertyCollection.
	/// </summary>
#if NET_2_0
	[Serializable]
#endif
	public class PropertyCollection : Hashtable {
		public PropertyCollection() 
		{
		}

#if NET_2_0
		protected PropertyCollection(System.Runtime.Serialization.SerializationInfo info,
					     System.Runtime.Serialization.StreamingContext context)
			: base (info, context)
		{
		}
#endif

		// the only public methods and properties 
		// are all inherited from Hashtable
	}
}
