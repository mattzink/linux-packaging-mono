//
// X500DistinguishedNameTest.cs - NUnit Test Cases for 
//	System.Security.Cryptography.X509Certificates.X500DistinguishedName
//
// Author:
//	Sebastien Pouliot  <sebastien@ximian.com>
//
// Copyright (C) 2005, 2006 Novell, Inc (http://www.novell.com)
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

#if NET_2_0

using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace MonoTests.System.Security.Cryptography.X509Certificates {

	[TestFixture]
	public class X500DistinguishedNameTest {

		private const string name = "OU=Secure Server Certification Authority, O=\"RSA Data Security, Inc.\", C=US";
		private const string rname = "C=US, O=\"RSA Data Security, Inc.\", OU=Secure Server Certification Authority";

		private static byte[] cert_a = { 0x30,0x82,0x01,0xFF,0x30,0x82,0x01,0x6C,0x02,0x05,0x02,0x72,0x00,0x06,0xE8,0x30,0x0D,0x06,0x09,0x2A,0x86,0x48,0x86,0xF7,0x0D,0x01,0x01,0x02,0x05,0x00,0x30,0x5F,0x31,0x0B,0x30,0x09,0x06,0x03,0x55,0x04,0x06,0x13,0x02,0x55,0x53,0x31,0x20,0x30,0x1E,0x06,0x03,0x55,0x04,0x0A,0x13,0x17,0x52,0x53,0x41,0x20,0x44,0x61,0x74,0x61,0x20,0x53,0x65,0x63,0x75,0x72,0x69,0x74,0x79,0x2C,0x20,0x49,0x6E,0x63,0x2E,0x31,0x2E,0x30,0x2C,0x06,0x03,0x55,0x04,0x0B,0x13,0x25,0x53,0x65,0x63,0x75,0x72,0x65,0x20,0x53,0x65,0x72,0x76,
			0x65,0x72,0x20,0x43,0x65,0x72,0x74,0x69,0x66,0x69,0x63,0x61,0x74,0x69,0x6F,0x6E,0x20,0x41,0x75,0x74,0x68,0x6F,0x72,0x69,0x74,0x79,0x30,0x1E,0x17,0x0D,0x39,0x36,0x30,0x33,0x31,0x32,0x31,0x38,0x33,0x38,0x34,0x37,0x5A,0x17,0x0D,0x39,0x37,0x30,0x33,0x31,0x32,0x31,0x38,0x33,0x38,0x34,0x36,0x5A,0x30,0x61,0x31,0x0B,0x30,0x09,0x06,0x03,0x55,0x04,0x06,0x13,0x02,0x55,0x53,0x31,0x13,0x30,0x11,0x06,0x03,0x55,0x04,0x08,0x13,0x0A,0x43,0x61,0x6C,0x69,0x66,0x6F,0x72,0x6E,0x69,0x61,0x31,0x14,0x30,0x12,0x06,0x03,
			0x55,0x04,0x0A,0x13,0x0B,0x43,0x6F,0x6D,0x6D,0x65,0x72,0x63,0x65,0x4E,0x65,0x74,0x31,0x27,0x30,0x25,0x06,0x03,0x55,0x04,0x0B,0x13,0x1E,0x53,0x65,0x72,0x76,0x65,0x72,0x20,0x43,0x65,0x72,0x74,0x69,0x66,0x69,0x63,0x61,0x74,0x69,0x6F,0x6E,0x20,0x41,0x75,0x74,0x68,0x6F,0x72,0x69,0x74,0x79,0x30,0x70,0x30,0x0D,0x06,0x09,0x2A,0x86,0x48,0x86,0xF7,0x0D,0x01,0x01,0x01,0x05,0x00,0x03,0x5F,0x00,0x30,0x5C,0x02,0x55,0x2D,0x58,0xE9,0xBF,0xF0,0x31,0xCD,0x79,0x06,0x50,0x5A,0xD5,0x9E,0x0E,0x2C,0xE6,0xC2,0xF7,0xF9,
			0xD2,0xCE,0x55,0x64,0x85,0xB1,0x90,0x9A,0x92,0xB3,0x36,0xC1,0xBC,0xEA,0xC8,0x23,0xB7,0xAB,0x3A,0xA7,0x64,0x63,0x77,0x5F,0x84,0x22,0x8E,0xE5,0xB6,0x45,0xDD,0x46,0xAE,0x0A,0xDD,0x00,0xC2,0x1F,0xBA,0xD9,0xAD,0xC0,0x75,0x62,0xF8,0x95,0x82,0xA2,0x80,0xB1,0x82,0x69,0xFA,0xE1,0xAF,0x7F,0xBC,0x7D,0xE2,0x7C,0x76,0xD5,0xBC,0x2A,0x80,0xFB,0x02,0x03,0x01,0x00,0x01,0x30,0x0D,0x06,0x09,0x2A,0x86,0x48,0x86,0xF7,0x0D,0x01,0x01,0x02,0x05,0x00,0x03,0x7E,0x00,0x54,0x20,0x67,0x12,0xBB,0x66,0x14,0xC3,0x26,0x6B,0x7F,
			0xDA,0x4A,0x25,0x4D,0x8B,0xE0,0xFD,0x1E,0x53,0x6D,0xAC,0xA2,0xD0,0x89,0xB8,0x2E,0x90,0xA0,0x27,0x43,0xA4,0xEE,0x4A,0x26,0x86,0x40,0xFF,0xB8,0x72,0x8D,0x1E,0xE7,0xB7,0x77,0xDC,0x7D,0xD8,0x3F,0x3A,0x6E,0x55,0x10,0xA6,0x1D,0xB5,0x58,0xF2,0xF9,0x0F,0x2E,0xB4,0x10,0x55,0x48,0xDC,0x13,0x5F,0x0D,0x08,0x26,0x88,0xC9,0xAF,0x66,0xF2,0x2C,0x9C,0x6F,0x3D,0xC3,0x2B,0x69,0x28,0x89,0x40,0x6F,0x8F,0x35,0x3B,0x9E,0xF6,0x8E,0xF1,0x11,0x17,0xFB,0x0C,0x98,0x95,0xA1,0xC2,0xBA,0x89,0x48,0xEB,0xB4,0x06,0x6A,0x22,0x54,
			0xD7,0xBA,0x18,0x3A,0x48,0xA6,0xCB,0xC2,0xFD,0x20,0x57,0xBC,0x63,0x1C };

		private static byte[] cert_a_issuer_raw = new byte[] { 0x30, 0x5F, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 0x55, 0x53, 0x31, 0x20, 0x30, 0x1E, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x17, 0x52, 0x53, 0x41, 0x20, 0x44, 0x61, 0x74, 0x61, 0x20, 0x53, 0x65, 0x63, 0x75, 0x72, 0x69, 0x74, 0x79, 0x2C, 0x20, 0x49, 0x6E, 0x63, 0x2E, 0x31, 0x2E, 0x30, 0x2C, 0x06, 0x03, 0x55, 0x04, 0x0B, 0x13, 0x25, 0x53, 0x65, 0x63, 0x75, 0x72, 0x65, 0x20, 0x53, 0x65, 0x72, 0x76, 0x65, 0x72, 0x20, 0x43, 0x65, 
			0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x20, 0x41, 0x75, 0x74, 0x68, 0x6F, 0x72, 0x69, 0x74, 0x79 };

		private static byte[] cert_b = { 0x30,0x82,0x03,0x04,0x30,0x82,0x02,0xC4,0xA0,0x03,0x02,0x01,0x02,0x02,0x01,0x03,0x30,0x09,0x06,0x07,0x2A,0x86,0x48,0xCE,0x38,0x04,0x03,0x30,0x51,0x31,0x0B,0x30,0x09,0x06,0x03,0x55,0x04,0x06,0x13,0x02,0x55,0x53,0x31,0x18,0x30,0x16,0x06,0x03,0x55,0x04,0x0A,0x13,0x0F,0x55,0x2E,0x53,0x2E,0x20,0x47,0x6F,0x76,0x65,0x72,0x6E,0x6D,0x65,0x6E,0x74,0x31,0x0C,0x30,0x0A,0x06,0x03,0x55,0x04,0x0B,0x13,0x03,0x44,0x6F,0x44,0x31,0x1A,0x30,0x18,0x06,0x03,0x55,0x04,0x03,0x13,0x11,0x41,0x72,0x6D,0x65,0x64,0x20,0x46,0x6F,
			0x72,0x63,0x65,0x73,0x20,0x52,0x6F,0x6F,0x74,0x30,0x1E,0x17,0x0D,0x30,0x30,0x31,0x30,0x32,0x35,0x30,0x30,0x30,0x30,0x30,0x30,0x5A,0x17,0x0D,0x30,0x33,0x30,0x31,0x30,0x31,0x30,0x30,0x30,0x30,0x30,0x30,0x5A,0x30,0x51,0x31,0x0B,0x30,0x09,0x06,0x03,0x55,0x04,0x06,0x13,0x02,0x55,0x53,0x31,0x18,0x30,0x16,0x06,0x03,0x55,0x04,0x0A,0x13,0x0F,0x55,0x2E,0x53,0x2E,0x20,0x47,0x6F,0x76,0x65,0x72,0x6E,0x6D,0x65,0x6E,0x74,0x31,0x0C,0x30,0x0A,0x06,0x03,0x55,0x04,0x0B,0x13,0x03,0x44,0x6F,0x44,0x31,0x1A,0x30,0x18,
			0x06,0x03,0x55,0x04,0x03,0x13,0x11,0x41,0x72,0x6D,0x65,0x64,0x20,0x46,0x6F,0x72,0x63,0x65,0x73,0x20,0x52,0x6F,0x6F,0x74,0x30,0x82,0x01,0xB6,0x30,0x82,0x01,0x2B,0x06,0x07,0x2A,0x86,0x48,0xCE,0x38,0x04,0x01,0x30,0x82,0x01,0x1E,0x02,0x81,0x81,0x00,0x90,0x89,0x3E,0x18,0x1B,0xFE,0xA3,0x1D,0x16,0x89,0x00,0xB4,0xD5,0x40,0x82,0x4C,0x2E,0xEC,0x3D,0x66,0x0D,0x0D,0xB9,0x17,0x40,0x6E,0x3A,0x5C,0x03,0x7B,0x1B,0x93,0x28,0x0C,0xEF,0xB9,0x97,0xE3,0xA1,0xEB,0xE2,0xA3,0x7C,0x61,0xDD,0x6F,0xD5,0xAD,0x15,0x69,0x00,
			0x16,0xB2,0xC3,0x08,0x3D,0xC4,0x59,0xC6,0xF2,0x70,0xA5,0xB0,0xF5,0x1F,0x1D,0xF4,0xB0,0x15,0xDA,0x7E,0x28,0x39,0x24,0x99,0x36,0x5B,0xEC,0x39,0x25,0xFA,0x92,0x49,0x65,0xD2,0x43,0x05,0x6A,0x9E,0xA3,0x7B,0xF0,0xDE,0xA3,0x2F,0xD3,0x6F,0x3A,0xF9,0x35,0xC3,0x29,0xD4,0x45,0x6C,0x56,0x9A,0xDE,0x36,0x6E,0xFE,0x12,0x68,0x96,0x7B,0x45,0x1D,0x2C,0xFF,0xB9,0x2D,0xF5,0x52,0x8C,0xDF,0x3E,0x2F,0x63,0x02,0x15,0x00,0x81,0xA9,0xB5,0xD0,0x04,0xF2,0x9B,0xA7,0xD8,0x55,0x4C,0x3B,0x32,0xA1,0x45,0x32,0x4F,0xF5,0x51,0xDD,
			0x02,0x81,0x80,0x64,0x7A,0x88,0x0B,0xF2,0x3E,0x91,0x81,0x59,0x9C,0xF4,0xEA,0xC6,0x7B,0x0E,0xBE,0xEA,0x05,0xE8,0x77,0xFD,0x20,0x34,0x87,0xA1,0xC4,0x69,0xF6,0xC8,0x8B,0x19,0xDA,0xCD,0xFA,0x21,0x8A,0x57,0xA9,0x7A,0x26,0x0A,0x56,0xD4,0xED,0x4B,0x1B,0x7C,0x70,0xED,0xB4,0xE6,0x7A,0x6A,0xDE,0xD3,0x29,0xE2,0xE9,0x9A,0x33,0xED,0x09,0x8D,0x9E,0xDF,0xDA,0x2E,0x4A,0xC1,0x50,0x92,0xEE,0x2F,0xE5,0x5A,0xF3,0x85,0x62,0x6A,0x48,0xDC,0x1B,0x02,0x98,0xA6,0xB0,0xD1,0x09,0x4B,0x10,0xD1,0xF0,0xFA,0xE0,0xB1,0x1D,0x13,
			0x54,0x4B,0xC0,0xA8,0x40,0xEF,0x71,0xE8,0x56,0x6B,0xA2,0x29,0xCB,0x1E,0x09,0x7D,0x27,0x39,0x91,0x3B,0x20,0x4F,0x98,0x39,0xE8,0x39,0xCA,0x98,0xC5,0xAF,0x54,0x03,0x81,0x84,0x00,0x02,0x81,0x80,0x54,0xA8,0x88,0xB5,0x8F,0x01,0x56,0xCE,0x18,0x8F,0xA6,0xD6,0x7C,0x29,0x29,0x75,0x45,0xE8,0x31,0xA4,0x07,0x17,0xED,0x1E,0x5D,0xB2,0x7B,0xBB,0xCE,0x3C,0x97,0x67,0x1E,0x88,0x0A,0xFE,0x7D,0x00,0x22,0x27,0x1D,0x66,0xEE,0xF6,0x1B,0xB6,0x95,0x7F,0x5A,0xFF,0x06,0x34,0x02,0x43,0xC3,0x83,0xC4,0x66,0x2C,0xA1,0x05,0x0E,
			0x68,0xB3,0xCA,0xDC,0xD3,0xF9,0x0C,0xC0,0x66,0xDF,0x85,0x84,0x4B,0x20,0x5D,0x41,0xAC,0xC0,0xEC,0x37,0x92,0x0E,0x97,0x19,0xBF,0x53,0x35,0x63,0x27,0x18,0x33,0x35,0x42,0x4D,0xF0,0x2D,0x6D,0xA7,0xA4,0x98,0xAA,0x57,0xF3,0xD2,0xB8,0x6E,0x4E,0x8F,0xFF,0xBE,0x6F,0x4E,0x0F,0x0B,0x44,0x24,0xEE,0xDF,0x4C,0x22,0x5B,0x44,0x98,0x94,0xCB,0xB8,0xA3,0x2F,0x30,0x2D,0x30,0x1D,0x06,0x03,0x55,0x1D,0x0E,0x04,0x16,0x04,0x14,0x9D,0x2D,0x73,0xC3,0xB8,0xE3,0x4D,0x29,0x28,0xC3,0x65,0xBE,0xA9,0x98,0xCB,0xD6,0x8A,0x06,0x68,
			0x9C,0x30,0x0C,0x06,0x03,0x55,0x1D,0x13,0x04,0x05,0x30,0x03,0x01,0x01,0xFF,0x30,0x09,0x06,0x07,0x2A,0x86,0x48,0xCE,0x38,0x04,0x03,0x03,0x2F,0x00,0x30,0x2C,0x02,0x14,0x5A,0x1B,0x2D,0x08,0x0E,0xE6,0x99,0x38,0x8F,0xB5,0x09,0xC9,0x89,0x79,0x7E,0x01,0x30,0xBD,0xCE,0xF0,0x02,0x14,0x71,0x7B,0x08,0x51,0x97,0xCE,0x4D,0x1F,0x6A,0x84,0x47,0x3A,0xC0,0xBD,0x13,0x89,0x81,0xB9,0x01,0x97 };

		static public byte[] RFC3280MandatoryAttributeTypesCACert_crt = { 0x30, 0x82, 0x02, 0xC1, 0x30, 0x82, 0x02, 0x2A, 0xA0, 0x03, 0x02, 0x01, 0x02, 0x02, 0x01, 0x60, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x05, 0x05, 0x00, 0x30, 0x40, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 0x55, 0x53, 0x31, 0x1A, 0x30, 0x18, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x11, 0x54, 0x65, 0x73, 0x74, 0x20, 0x43, 0x65, 0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x65, 0x73, 0x31, 0x15, 0x30, 0x13, 0x06, 0x03, 0x55, 0x04, 0x03, 0x13, 0x0C, 0x54, 0x72, 0x75, 0x73, 0x74, 0x20, 0x41, 0x6E, 0x63, 0x68, 0x6F, 0x72, 0x30, 0x1E, 0x17, 0x0D, 
			0x30, 0x31, 0x30, 0x34, 0x31, 0x39, 0x31, 0x34, 0x35, 0x37, 0x32, 0x30, 0x5A, 0x17, 0x0D, 0x31, 0x31, 0x30, 0x34, 0x31, 0x39, 0x31, 0x34, 0x35, 0x37, 0x32, 0x30, 0x5A, 0x30, 0x81, 0x8E, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 0x55, 0x53, 0x31, 0x1A, 0x30, 0x18, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x11, 0x54, 0x65, 0x73, 0x74, 0x20, 0x43, 0x65, 0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x65, 0x73, 0x31, 0x13, 0x30, 0x11, 0x06, 0x0A, 0x09, 0x92, 0x26, 0x89, 0x93, 0xF2, 0x2C, 0x64, 0x01, 0x19, 0x16, 0x03, 0x67, 0x6F, 0x76, 0x31, 0x20, 0x30, 0x1E, 0x06, 0x0A, 0x09, 
			0x92, 0x26, 0x89, 0x93, 0xF2, 0x2C, 0x64, 0x01, 0x19, 0x16, 0x10, 0x74, 0x65, 0x73, 0x74, 0x63, 0x65, 0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x65, 0x73, 0x31, 0x11, 0x30, 0x0F, 0x06, 0x03, 0x55, 0x04, 0x08, 0x13, 0x08, 0x4D, 0x61, 0x72, 0x79, 0x6C, 0x61, 0x6E, 0x64, 0x31, 0x0C, 0x30, 0x0A, 0x06, 0x03, 0x55, 0x04, 0x05, 0x13, 0x03, 0x33, 0x34, 0x35, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x2E, 0x13, 0x02, 0x43, 0x41, 0x30, 0x81, 0x9F, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00, 0x03, 0x81, 0x8D, 0x00, 0x30, 0x81, 0x89, 0x02, 0x81, 
			0x81, 0x00, 0x98, 0xF9, 0xAF, 0xBC, 0xDB, 0x8B, 0x05, 0xA5, 0xE2, 0xDD, 0xC6, 0x10, 0x43, 0x3B, 0x8D, 0x14, 0xEB, 0x6A, 0xD9, 0xA7, 0x8D, 0xAB, 0x56, 0x19, 0xA1, 0xD4, 0xFF, 0xFB, 0xB4, 0x92, 0x7E, 0x39, 0x76, 0xBB, 0x3D, 0x70, 0xB0, 0xB1, 0xC8, 0xED, 0x78, 0xCE, 0x18, 0xEB, 0x96, 0xAC, 0x4F, 0x4D, 0xD2, 0x83, 0x41, 0xAC, 0x04, 0x66, 0x49, 0x88, 0x7A, 0x5A, 0xB6, 0x02, 0x26, 0x3D, 0x5C, 0x77, 0xCB, 0xDC, 0x8F, 0xE1, 0x53, 0xCA, 0x6B, 0xF1, 0xE4, 0x35, 0x84, 0x7A, 0xA3, 0xC2, 0x0E, 0x6C, 0x54, 0x10, 0xEE, 0x1E, 0xFB, 0xF4, 0x7E, 0xBA, 0xD1, 0xEC, 0x16, 0x60, 0x91, 0xCE, 0xB3, 0x8E, 0x50, 0x4A, 
			0x8A, 0x92, 0x21, 0xCD, 0x1A, 0x84, 0x77, 0x8B, 0x2A, 0xD8, 0xAF, 0x9C, 0xEC, 0xCC, 0x94, 0x60, 0x44, 0x3C, 0x1F, 0xD5, 0x08, 0x98, 0x22, 0x7B, 0xB4, 0x70, 0xB3, 0x2C, 0x1E, 0xBF, 0x02, 0x03, 0x01, 0x00, 0x01, 0xA3, 0x7C, 0x30, 0x7A, 0x30, 0x1F, 0x06, 0x03, 0x55, 0x1D, 0x23, 0x04, 0x18, 0x30, 0x16, 0x80, 0x14, 0xFB, 0x6C, 0xD4, 0x2D, 0x81, 0x9E, 0xCA, 0x27, 0x7A, 0x9E, 0x0D, 0xB0, 0x3C, 0xEA, 0x9A, 0xBC, 0x87, 0xFF, 0x49, 0xEA, 0x30, 0x1D, 0x06, 0x03, 0x55, 0x1D, 0x0E, 0x04, 0x16, 0x04, 0x14, 0xA0, 0x2D, 0x8D, 0xA0, 0x5C, 0xA8, 0x82, 0x08, 0x62, 0x2A, 0x36, 0xA2, 0x4D, 0x52, 0xC8, 0xE5, 0x2C, 
			0x50, 0x7D, 0x2B, 0x30, 0x0E, 0x06, 0x03, 0x55, 0x1D, 0x0F, 0x01, 0x01, 0xFF, 0x04, 0x04, 0x03, 0x02, 0x01, 0x06, 0x30, 0x17, 0x06, 0x03, 0x55, 0x1D, 0x20, 0x04, 0x10, 0x30, 0x0E, 0x30, 0x0C, 0x06, 0x0A, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x02, 0x01, 0x30, 0x01, 0x30, 0x0F, 0x06, 0x03, 0x55, 0x1D, 0x13, 0x01, 0x01, 0xFF, 0x04, 0x05, 0x30, 0x03, 0x01, 0x01, 0xFF, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x05, 0x05, 0x00, 0x03, 0x81, 0x81, 0x00, 0x97, 0xA1, 0x70, 0x88, 0x1F, 0x94, 0xEE, 0x09, 0xFF, 0x38, 0x75, 0x53, 0xB0, 0x79, 0x23, 0x1F, 0x39, 0xD6, 0xF9, 0x33, 
			0x32, 0x93, 0xB9, 0xD3, 0xB0, 0xE7, 0x99, 0x94, 0xED, 0x58, 0x03, 0xCC, 0xC9, 0x3B, 0xBF, 0x34, 0x08, 0x13, 0x1D, 0xE3, 0x09, 0xE3, 0xF4, 0xEE, 0x1F, 0x1B, 0xC8, 0x33, 0x34, 0x8B, 0xFA, 0x24, 0x8C, 0xDD, 0x14, 0x82, 0x6E, 0x03, 0xCC, 0xEC, 0x31, 0xC7, 0x99, 0x40, 0x8E, 0xCF, 0xEE, 0x18, 0x68, 0x46, 0x44, 0x60, 0x55, 0x08, 0x92, 0x0F, 0x43, 0x84, 0x1E, 0x9A, 0xC5, 0xF7, 0x2F, 0x6E, 0x18, 0xA6, 0xA4, 0x90, 0x2A, 0x82, 0x63, 0x2B, 0xE6, 0x0B, 0xFA, 0xCC, 0xFC, 0xA5, 0xDA, 0x1A, 0xA9, 0x7E, 0xBD, 0x74, 0x30, 0x32, 0x21, 0xC6, 0x4D, 0x1B, 0x68, 0xBD, 0x2F, 0xF5, 0x84, 0xBE, 0x66, 0x9C, 0xC3, 0x40, 
			0x27, 0x25, 0x9F, 0x91, 0x77, 0x4E, 0xA3, 0xAB };

		static public byte[] RFC3280OptionalAttributeTypesCACert_crt = { 0x30, 0x82, 0x02, 0xCD, 0x30, 0x82, 0x02, 0x36, 0xA0, 0x03, 0x02, 0x01, 0x02, 0x02, 0x01, 0x61, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x05, 0x05, 0x00, 0x30, 0x40, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 0x55, 0x53, 0x31, 0x1A, 0x30, 0x18, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x11, 0x54, 0x65, 0x73, 0x74, 0x20, 0x43, 0x65, 0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x65, 0x73, 0x31, 0x15, 0x30, 0x13, 0x06, 0x03, 0x55, 0x04, 0x03, 0x13, 0x0C, 0x54, 0x72, 0x75, 0x73, 0x74, 0x20, 0x41, 0x6E, 0x63, 0x68, 0x6F, 0x72, 0x30, 0x1E, 0x17, 0x0D, 
			0x30, 0x31, 0x30, 0x34, 0x31, 0x39, 0x31, 0x34, 0x35, 0x37, 0x32, 0x30, 0x5A, 0x17, 0x0D, 0x31, 0x31, 0x30, 0x34, 0x31, 0x39, 0x31, 0x34, 0x35, 0x37, 0x32, 0x30, 0x5A, 0x30, 0x81, 0x9A, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 0x55, 0x53, 0x31, 0x1A, 0x30, 0x18, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x11, 0x54, 0x65, 0x73, 0x74, 0x20, 0x43, 0x65, 0x72, 0x74, 0x69, 0x66, 0x69, 0x63, 0x61, 0x74, 0x65, 0x73, 0x31, 0x15, 0x30, 0x13, 0x06, 0x03, 0x55, 0x04, 0x07, 0x13, 0x0C, 0x47, 0x61, 0x69, 0x74, 0x68, 0x65, 0x72, 0x73, 0x62, 0x75, 0x72, 0x67, 0x31, 0x0D, 0x30, 0x0B, 0x06, 
			0x03, 0x55, 0x04, 0x2A, 0x13, 0x04, 0x4A, 0x6F, 0x68, 0x6E, 0x31, 0x0A, 0x30, 0x08, 0x06, 0x03, 0x55, 0x04, 0x2B, 0x13, 0x01, 0x51, 0x31, 0x13, 0x30, 0x11, 0x06, 0x03, 0x55, 0x04, 0x41, 0x13, 0x0A, 0x46, 0x69, 0x63, 0x74, 0x69, 0x74, 0x69, 0x6F, 0x75, 0x73, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x04, 0x13, 0x02, 0x43, 0x41, 0x31, 0x0C, 0x30, 0x0A, 0x06, 0x03, 0x55, 0x04, 0x2C, 0x13, 0x03, 0x49, 0x49, 0x49, 0x31, 0x0D, 0x30, 0x0B, 0x06, 0x03, 0x55, 0x04, 0x0C, 0x13, 0x04, 0x4D, 0x2E, 0x44, 0x2E, 0x30, 0x81, 0x9F, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 
			0x01, 0x05, 0x00, 0x03, 0x81, 0x8D, 0x00, 0x30, 0x81, 0x89, 0x02, 0x81, 0x81, 0x00, 0xD6, 0xB6, 0x15, 0x6C, 0x19, 0x45, 0x8B, 0xE6, 0x80, 0xBC, 0x11, 0x32, 0x0B, 0x53, 0x87, 0x6B, 0x0D, 0x4A, 0xA0, 0xD2, 0xC0, 0x49, 0xBC, 0x16, 0x25, 0x05, 0x36, 0x33, 0x64, 0x75, 0xF0, 0xC2, 0x7A, 0xD2, 0x9F, 0xC4, 0xB7, 0x6E, 0x25, 0x0B, 0x98, 0x4F, 0x9C, 0x8F, 0x7E, 0x21, 0xAA, 0x9A, 0xD0, 0x94, 0x87, 0x60, 0x9D, 0x21, 0x63, 0x8A, 0x96, 0x73, 0x07, 0x89, 0x3A, 0xD3, 0x5C, 0x4C, 0xD8, 0xC0, 0x80, 0xF7, 0xBF, 0x8F, 0x1B, 0x10, 0x3C, 0x83, 0x89, 0x78, 0x8E, 0x63, 0xD1, 0x90, 0xC8, 0xEF, 0xDC, 0x20, 0xBE, 0x3D, 
			0x05, 0xEC, 0xA2, 0xD6, 0xE5, 0x02, 0xB2, 0x0D, 0xB7, 0x36, 0xDB, 0x47, 0xB0, 0xF8, 0x53, 0x11, 0xD8, 0xAA, 0x6D, 0xA8, 0x03, 0xF1, 0xBF, 0x87, 0xB1, 0x80, 0x80, 0xA8, 0xA1, 0xA8, 0x8B, 0x33, 0xCB, 0x0E, 0x2D, 0xD3, 0x7D, 0xBB, 0xF0, 0x2A, 0x2E, 0x8B, 0x02, 0x03, 0x01, 0x00, 0x01, 0xA3, 0x7C, 0x30, 0x7A, 0x30, 0x1F, 0x06, 0x03, 0x55, 0x1D, 0x23, 0x04, 0x18, 0x30, 0x16, 0x80, 0x14, 0xFB, 0x6C, 0xD4, 0x2D, 0x81, 0x9E, 0xCA, 0x27, 0x7A, 0x9E, 0x0D, 0xB0, 0x3C, 0xEA, 0x9A, 0xBC, 0x87, 0xFF, 0x49, 0xEA, 0x30, 0x1D, 0x06, 0x03, 0x55, 0x1D, 0x0E, 0x04, 0x16, 0x04, 0x14, 0xAF, 0x81, 0x9F, 0xCC, 0x19, 
			0x2C, 0x12, 0xA4, 0x63, 0x42, 0x57, 0x57, 0xD7, 0x57, 0x1A, 0x63, 0x07, 0x5F, 0x73, 0xD1, 0x30, 0x0E, 0x06, 0x03, 0x55, 0x1D, 0x0F, 0x01, 0x01, 0xFF, 0x04, 0x04, 0x03, 0x02, 0x01, 0x06, 0x30, 0x17, 0x06, 0x03, 0x55, 0x1D, 0x20, 0x04, 0x10, 0x30, 0x0E, 0x30, 0x0C, 0x06, 0x0A, 0x60, 0x86, 0x48, 0x01, 0x65, 0x03, 0x02, 0x01, 0x30, 0x01, 0x30, 0x0F, 0x06, 0x03, 0x55, 0x1D, 0x13, 0x01, 0x01, 0xFF, 0x04, 0x05, 0x30, 0x03, 0x01, 0x01, 0xFF, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x05, 0x05, 0x00, 0x03, 0x81, 0x81, 0x00, 0x53, 0xE9, 0xC6, 0x5A, 0x3C, 0xFA, 0x11, 0xDA, 
			0x3C, 0x93, 0xB1, 0xA8, 0xB2, 0x91, 0xE7, 0x42, 0x77, 0x87, 0xED, 0xB5, 0x31, 0x82, 0xFF, 0xB9, 0xF3, 0x23, 0x9B, 0x3A, 0xFE, 0xB8, 0x85, 0xE6, 0x7C, 0x52, 0x46, 0x1A, 0x0B, 0x33, 0xE8, 0x7C, 0x85, 0xAF, 0xB3, 0x37, 0x67, 0x5F, 0xD7, 0x13, 0x19, 0x6A, 0x8D, 0x4E, 0xBE, 0x9E, 0x91, 0x40, 0x63, 0x8F, 0xAD, 0xBB, 0x8F, 0x87, 0x3F, 0x2A, 0xC2, 0x79, 0x98, 0xAE, 0x36, 0x76, 0x7D, 0xDB, 0xE3, 0xE3, 0xBB, 0x23, 0xF8, 0x14, 0x18, 0xC4, 0x83, 0xBA, 0xA1, 0x4C, 0x9D, 0xFC, 0x36, 0x18, 0xC0, 0x8F, 0xE7, 0x9A, 0xAD, 0xE8, 0xE5, 0xB2, 0xC1, 0x3B, 0x16, 0x43, 0xCF, 0x7A, 0x82, 0xDC, 0x08, 0x8D, 0x15, 0xF7, 
			0x1F, 0x2C, 0xF8, 0x99, 0xDA, 0x6D, 0x1E, 0xA2, 0xD3, 0xF4, 0x23, 0xBF, 0x27, 0x4E, 0xD0, 0xC6, 0x19, 0x40, 0xDC, 0x13 };

		static public AsnEncodedData emptyData = new AsnEncodedData (new byte[0]);

		private X509Certificate2 x509a;
		private X509Certificate2 x509b;

		[TestFixtureSetUp]
		public void FixtureSetUp ()
		{
			x509a = new X509Certificate2 (cert_a);
			x509b = new X509Certificate2 (cert_b);
		}

		private void Empty (X500DistinguishedName dn)
		{
			Assert.AreEqual (String.Empty, dn.Name, "Name");

			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.None), "Decode(None)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.Reversed), "Decode(Reversed)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.UseSemicolons), "Decode(UseSemicolons)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.DoNotUsePlusSign), "Decode(DoNotUsePlusSign)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.DoNotUseQuotes), "Decode(DoNotUseQuotes)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.UseCommas), "Decode(UseCommas)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.UseNewLines), "Decode(UseNewLines)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.UseUTF8Encoding), "Decode(UseUTF8Encoding)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.UseT61Encoding), "Decode(UseT61Encoding)");
			Assert.AreEqual (String.Empty, dn.Decode (X500DistinguishedNameFlags.ForceUTF8Encoding), "Decode(ForceUTF8Encoding)");

			Assert.AreEqual (String.Empty, dn.Format (true), "Format(true)");
			Assert.AreEqual (String.Empty, dn.Format (false), "Format(false)");
		}

		private void RsaIssuer (X500DistinguishedName dn)
		{
			Assert.AreEqual (name, dn.Name, "Name");
			Assert.AreEqual (97, dn.RawData.Length, "RawData");

			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.None), "Decode(None)");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.Reversed), "Decode(Reversed)");
			Assert.AreEqual ("C=US; O=\"RSA Data Security, Inc.\"; OU=Secure Server Certification Authority", dn.Decode (X500DistinguishedNameFlags.UseSemicolons), "Decode(UseSemicolons)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.DoNotUsePlusSign), "Decode(DoNotUsePlusSign)");
			Assert.AreEqual ("C=US, O=RSA Data Security, Inc., OU=Secure Server Certification Authority", dn.Decode (X500DistinguishedNameFlags.DoNotUseQuotes), "Decode(DoNotUseQuotes)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseCommas), "Decode(UseCommas)");
			string newline = String.Format ("C=US{0}O=\"RSA Data Security, Inc.\"{0}OU=Secure Server Certification Authority", Environment.NewLine);
			Assert.AreEqual (newline, dn.Decode (X500DistinguishedNameFlags.UseNewLines), "Decode(UseNewLines)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseUTF8Encoding), "Decode(UseUTF8Encoding)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseT61Encoding), "Decode(UseT61Encoding)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.ForceUTF8Encoding), "Decode(ForceUTF8Encoding)");

			Assert.AreEqual (newline + Environment.NewLine, dn.Format (true), "Format(true)");
			Assert.AreEqual (rname, dn.Format (false), "Format(false)");
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void Constructor_AsnEncodedData_Null ()
		{
			new X500DistinguishedName ((AsnEncodedData) null);
		}

		[Test]
		public void Constructor_AsnEncodedData_Empty ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (emptyData);
			Assert.IsNull (dn.Oid, "Oid");
			Assert.AreEqual (0, dn.RawData.Length, "RawData");
			Empty (dn);
		}

		[Test]
		public void Constructor_AsnEncodedData ()
		{
			AsnEncodedData aed = new AsnEncodedData (cert_a_issuer_raw);
			X500DistinguishedName dn = new X500DistinguishedName (aed);
			Assert.IsNull (dn.Oid, "Oid");
			RsaIssuer (dn);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void Constructor_ByteArray_Null ()
		{
			new X500DistinguishedName ((byte[]) null);
		}

		[Test]
		public void Constructor_ByteArray_Empty ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (new byte[0]);
			Assert.IsNotNull (dn.Oid, "Oid");
			Assert.IsNull (dn.Oid.Value, "Oid.Value");
			Assert.IsNull (dn.Oid.FriendlyName, "Oid.FriendlyName");
			Assert.AreEqual (0, dn.RawData.Length, "RawData");
			Empty (dn);
		}

		[Test]
		public void Constructor_ByteArray ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (cert_a_issuer_raw);
			Assert.IsNotNull (dn.Oid, "Oid");
			Assert.IsNull (dn.Oid.Value, "Oid.Value");
			Assert.IsNull (dn.Oid.FriendlyName, "Oid.FriendlyName");
			RsaIssuer (dn);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void Constructor_String_Null ()
		{
			new X500DistinguishedName ((string) null);
		}

		[Test]
		public void Constructor_String_Empty ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (String.Empty);
			Assert.AreEqual (2, dn.RawData.Length, "RawData.Length");
			Assert.AreEqual ("30-00", BitConverter.ToString (dn.RawData), "RawData");
			Empty (dn);
		}

		[Test]
		public void Constructor_String ()
		{
			X500DistinguishedName dn = new X500DistinguishedName ("OU=Secure Server Certification Authority, O=\"RSA Data Security, Inc.\", C=US");
			Assert.IsNotNull (dn.Oid, "Oid");
			Assert.IsNull (dn.Oid.Value, "Oid.Value");
			Assert.IsNull (dn.Oid.FriendlyName, "Oid.FriendlyName");
			RsaIssuer (dn);
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void Constructor_String_Null_Flags ()
		{
			new X500DistinguishedName ((string) null, X500DistinguishedNameFlags.None);
		}

		[Test]
		public void Constructor_String_Empty_Flags ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (String.Empty, X500DistinguishedNameFlags.None);
			Assert.AreEqual (2, dn.RawData.Length, "RawData.Length");
			Assert.AreEqual ("30-00", BitConverter.ToString (dn.RawData), "RawData");
			Empty (dn);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void Constructor_String_Empty_Flags_Bad ()
		{
			X500DistinguishedNameFlags flags = (X500DistinguishedNameFlags)Int32.MinValue;
			new X500DistinguishedName (String.Empty, flags);
		}

		[Test]
		public void Constructor_String_Flags_None ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (rname, X500DistinguishedNameFlags.None);
			// can't call RsaIssuer because Name is reversed from None in those cases
			// i.e. X500DistinguishedName (string) != X500DistinguishedName (string, X500DistinguishedNameFlags)
			Assert.AreEqual (rname, dn.Name, "Name");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.None), "Decode(None)");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.Reversed), "Decode(Reversed)");
			Assert.AreEqual ("C=US; O=\"RSA Data Security, Inc.\"; OU=Secure Server Certification Authority", dn.Decode (X500DistinguishedNameFlags.UseSemicolons), "Decode(UseSemicolons)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.DoNotUsePlusSign), "Decode(DoNotUsePlusSign)");
			Assert.AreEqual ("C=US, O=RSA Data Security, Inc., OU=Secure Server Certification Authority", dn.Decode (X500DistinguishedNameFlags.DoNotUseQuotes), "Decode(DoNotUseQuotes)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseCommas), "Decode(UseCommas)");
			string newline = String.Format ("C=US{0}O=\"RSA Data Security, Inc.\"{0}OU=Secure Server Certification Authority", Environment.NewLine);
			Assert.AreEqual (newline, dn.Decode (X500DistinguishedNameFlags.UseNewLines), "Decode(UseNewLines)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseUTF8Encoding), "Decode(UseUTF8Encoding)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseT61Encoding), "Decode(UseT61Encoding)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.ForceUTF8Encoding), "Decode(ForceUTF8Encoding)");
		}

		[Test]
		public void Constructor_String_Flags_Reversed ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (name, X500DistinguishedNameFlags.None);
			// can't call RsaIssuer because Name is reversed from None in those cases
			Assert.AreEqual (name, dn.Name, "Name");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.None), "Decode(None)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.Reversed), "Decode(Reversed)");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.DoNotUsePlusSign), "Decode(DoNotUsePlusSign)");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.UseCommas), "Decode(UseCommas)");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.UseUTF8Encoding), "Decode(UseUTF8Encoding)");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.UseT61Encoding), "Decode(UseT61Encoding)");
			Assert.AreEqual (name, dn.Decode (X500DistinguishedNameFlags.ForceUTF8Encoding), "Decode(ForceUTF8Encoding)");
		}

		[Test]
		[ExpectedException (typeof (ArgumentNullException))]
		public void Constructor_X500DistinguishedName_Null ()
		{
			new X500DistinguishedName ((X500DistinguishedName) null);
		}

		[Test]
		public void Constructor_X500DistinguishedName ()
		{
			X500DistinguishedName dn = new X500DistinguishedName (x509a.IssuerName);
			Assert.IsNotNull (dn.Oid, "Oid");
			Assert.IsNull (dn.Oid.Value, "Oid.Value");
			Assert.IsNull (dn.Oid.FriendlyName, "Oid.FriendlyName");
			RsaIssuer (dn);
		}

		[Test]
		[ExpectedException (typeof (ArgumentException))]
		public void Decode_BadFlag ()
		{
			new X500DistinguishedName (rname).Decode ((X500DistinguishedNameFlags) Int32.MinValue);
		}

		[Test]
		public void Decode_Separators ()
		{
			string semicolons = "C=US; O=\"RSA Data Security, Inc.\"; OU=Secure Server Certification Authority";
			string newline = String.Format ("C=US{0}O=\"RSA Data Security, Inc.\"{0}OU=Secure Server Certification Authority", Environment.NewLine);
			X500DistinguishedName dn = new X500DistinguishedName (rname, X500DistinguishedNameFlags.None);
			Assert.AreEqual (rname, dn.Name, "Name");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.None), "Decode(None)");

			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseCommas), "Decode(UseCommas)");
			Assert.AreEqual (semicolons, dn.Decode (X500DistinguishedNameFlags.UseSemicolons), "Decode(UseCommas|UseSemicolons)");
			Assert.AreEqual (newline, dn.Decode (X500DistinguishedNameFlags.UseNewLines), "Decode(UseNewLines)");

			Assert.AreEqual (semicolons, dn.Decode (X500DistinguishedNameFlags.UseCommas | X500DistinguishedNameFlags.UseSemicolons), "Decode(UseCommas|UseSemicolons)");
			Assert.AreEqual (semicolons, dn.Decode (X500DistinguishedNameFlags.UseNewLines | X500DistinguishedNameFlags.UseSemicolons), "Decode(UseNewLines|UseSemicolons)");
			Assert.AreEqual (rname, dn.Decode (X500DistinguishedNameFlags.UseCommas | X500DistinguishedNameFlags.UseNewLines), "Decode(UseCommas|UseNewLines)");
		}

		[Test]
		public void RFC3280MandatoryAttributeTypes ()
		{
			string expected = "dnQualifier=CA, OID.2.5.4.5=345, S=Maryland, DC=testcertificates, DC=gov, O=Test Certificates, C=US";
			X509Certificate2 cert = new X509Certificate2 (RFC3280MandatoryAttributeTypesCACert_crt);
			// note: strangely the (also CryptoAPI based) certificate viewer in Windows seems to resolve 2.5.4.5 as "Serial Number"
			Assert.AreEqual (expected, cert.SubjectName.Name, "SubjectName");
			X500DistinguishedName build = new X500DistinguishedName (expected);
			Assert.AreEqual (expected, build.Name, "Name");
		}

		[Test]
		public void RFC3280OptionalAttributeTypes ()
		{
			string expected = "T=M.D., OID.2.5.4.44=III, SN=CA, OID.2.5.4.65=Fictitious, I=Q, G=John, L=Gaithersburg, O=Test Certificates, C=US";
			X509Certificate2 cert = new X509Certificate2 (RFC3280OptionalAttributeTypesCACert_crt);
			Assert.AreEqual (expected, cert.SubjectName.Name, "SubjectName");
			X500DistinguishedName build = new X500DistinguishedName (expected);
			Assert.AreEqual (expected, build.Name, "Name");
		}

		[Test]
		public void T61String ()
		{
			// http://bugzilla.ximian.com/show_bug.cgi?id=77295
			byte[] sn = { 0x30, 0x81, 0xB5, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13, 0x02, 0x44, 0x4B, 0x31, 0x2D, 0x30, 0x2B, 0x06, 
				0x03, 0x55, 0x04, 0x0A, 0x14, 0x24, 0x48, 0x65, 0x64, 0x65, 0x62, 0x79, 0x27, 0x73, 0x20, 0x4D, 0xF8, 0x62, 0x65, 0x6C, 0x68, 0x61, 
				0x6E, 0x64, 0x65, 0x6C, 0x20, 0x2F, 0x2F, 0x20, 0x43, 0x56, 0x52, 0x3A, 0x31, 0x33, 0x34, 0x37, 0x31, 0x39, 0x36, 0x37, 0x31, 0x2F, 
				0x30, 0x2D, 0x06, 0x03, 0x55, 0x04, 0x03, 0x14, 0x26, 0x48, 0x65, 0x64, 0x65, 0x62, 0x79, 0x27, 0x73, 0x20, 0x4D, 0xF8, 0x62, 0x65, 
				0x6C, 0x68, 0x61, 0x6E, 0x64, 0x65, 0x6C, 0x20, 0x2D, 0x20, 0x53, 0x61, 0x6C, 0x67, 0x73, 0x61, 0x66, 0x64, 0x65, 0x6C, 0x69, 0x6E, 
				0x67, 0x65, 0x6E, 0x31, 0x1E, 0x30, 0x1C, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x09, 0x01, 0x16, 0x0F, 0x76, 0x68, 
				0x6D, 0x40, 0x75, 0x73, 0x65, 0x2E, 0x74, 0x65, 0x73, 0x74, 0x2E, 0x64, 0x6B, 0x31, 0x26, 0x30, 0x24, 0x06, 0x03, 0x55, 0x04, 0x05, 
				0x13, 0x1D, 0x43, 0x56, 0x52, 0x3A, 0x31, 0x33, 0x34, 0x37, 0x31, 0x39, 0x36, 0x37, 0x2D, 0x55, 0x49, 0x44, 0x3A, 0x31, 0x32, 0x31, 
				0x32, 0x31, 0x32, 0x31, 0x32, 0x31, 0x32, 0x31, 0x32 };
			X500DistinguishedName dn = new X500DistinguishedName (sn);
			string subject = "OID.2.5.4.5=CVR:13471967-UID:121212121212, E=vhm@use.test.dk, CN=Hedeby's Møbelhandel - Salgsafdelingen, O=Hedeby's Møbelhandel // CVR:13471967, C=DK";
			Assert.AreEqual (subject, dn.Name, "Name");
		}
	}
}

#endif
