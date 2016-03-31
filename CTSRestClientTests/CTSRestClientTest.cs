using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fiehnlab.CTSRest;
using System.Collections.Generic;

namespace Fiehnlab.CTSRestTests {
	[TestClass]
	public class CtsRestClientTest {
		List<string> top15 = new List<string>();

		[TestInitialize]
		public void setUp() {
			top15.Add("BioCyc");
			top15.Add("CAS");
			top15.Add("ChEBI");
			top15.Add("Chemical Name");
			top15.Add("Human Metabolome Database");
			top15.Add("InChI Code");
			top15.Add("InChIKey");
			top15.Add("KEGG");
			top15.Add("LMSD");
			top15.Add("LipidMAPS");
			top15.Add("PubChem CID");
			top15.Add("Pubchem SID");
			top15.Add("ChemSpider");
			top15.Add("ChemDB");
			top15.Add("ChEMBL");
		}

		[TestMethod]
		public void testGetToValues() {
			var client = new CtsRestClient();

			List<string> idNames = client.GetIdNames();
            Console.WriteLine("idnames: " + idNames.Count);
			var res = idNames.GetRange(0, 15);

            List<string> exp = top15;

			Assert.IsNotNull(idNames);
			Assert.IsTrue(idNames.Count > 0);
			Assert.AreEqual(exp.Count, res.Count);
			CollectionAssert.AreEquivalent(exp, res);
		}

		[TestMethod]
		public void testGetFromValues() {
			var client = new CtsRestClient();

			List<string> idNames = client.GetIdNames(true);

			var res = idNames.GetRange(0, 14);

			List<string> exp = top15;
			exp.Remove(CTSRest.Properties.Resources.INCHI_CODE);

			Assert.IsNotNull(idNames);
			Assert.IsTrue(idNames.Count > 0);
			Assert.AreEqual(exp.Count, res.Count);
			CollectionAssert.AreEquivalent(exp, res);
		}
	}
}
