/***************************************************************************************************
*
* Copyright (c) 2013 - 2020 Universitat Politecnica de Valencia - www.upv.es
* Copyright (c) 2018 - 2020 Open Universiteit - www.ou.nl
*
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*
* 1. Redistributions of source code must retain the above copyright notice,
* this list of conditions and the following disclaimer.
* 2. Redistributions in binary form must reproduce the above copyright
* notice, this list of conditions and the following disclaimer in the
* documentation and/or other materials provided with the distribution.
* 3. Neither the name of the copyright holder nor the names of its
* contributors may be used to endorse or promote products derived from
* this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
* AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
* ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE
* LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
* CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
* SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
* INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
* CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
* ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
* POSSIBILITY OF SUCH DAMAGE.
*******************************************************************************************************/

/**
 *  @author Sebastian Bauersfeld
 */
using System.Collections.ObjectModel;
using System;

namespace org.testar.monkey {	

	public class Assert {
		private Assert() { }

		public static void IsTrue(bool expression, string text) {
			if (!expression)
				throw new ArgumentException(text);
		}

		public static void IsTrue(bool expression) {
			if (!expression)
				throw new ArgumentException("You passed illegal parameters!");
		}

		public static void NotNull(object o1, string text) {
			if (o1 == null)
				throw new ArgumentException(text);
		}

		public static object NotNull(object o1) {
			if (o1 == null)
				throw new ArgumentException("You passed null as a parameter!");
			return o1;
		}

		public static void NotNull(object o1, object o2) {
			if (o1 == null || o2 == null)
				throw new ArgumentException("You passed null as a parameter!");
		}

		public static void NotNull(object o1, object o2, object o3) {
			if (o1 == null || o2 == null || o3 == null)
				throw new ArgumentException("You passed null as a parameter!");
		}

		public static void HasText(string str) {
			if (str == null || str.Length == 0)
				throw new ArgumentException("You passed a null or empty string!");
		}

		public static void HasTextSetting(string str, string settingName) {
			if (str == null || str.Length == 0) {
				string message = "Non valid setting value!\n"
						+ string.Format("It seems that setting %s as null or empty string!\n", settingName)
						+ "Please provide a correct string value using TESTAR GUI or test.setting file";
				throw new ArgumentException(message);
			}
		}

		public static void CollectionContains(Collection<string> collection, string value) {
			if (!collection.Contains(value)) {
				string message = string.Format("Collection %s doesn't contain desired value %s", collection.ToString(), value);
				throw new ArgumentException(message);
			}
		}

		public static void CollectionNotContains(Collection<string> collection, string value) {
			if (collection.Contains(value)) {
				string message = string.Format("Collection %s contains undesired value %s", collection.ToString(), value);
				throw new ArgumentException(message);
			}
		}

		public static void CollectionSize(Collection<String> collection, int size) {
			if (collection.Count != size) {
				string message = string.Format("Collection %s has undesired size %s", collection.ToString(), size);
				throw new ArgumentException(message);
			}
		}		
	}
}
