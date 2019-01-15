﻿// Copyright (c) 2015, 2016 Sedat Kapanoglu
// MIT License - see LICENSE file for details

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace HashDepot.Test
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class Fnv1Test
    {
        public static IEnumerable<object[]> TestData = FnvVectors.GetFnv1TestVectors()
            .Select(v => new object[] { v })
            .ToArray();

        [Test]
        [TestCaseSource("TestData")]
        public void Hash32_Stream_ReturnsExpectedValues(FnvTestVector data)
        {
            using (var stream = new MemoryStream(data.Buffer))
            {
                uint result = Fnv1.Hash32(stream);
                Assert.AreEqual(data.ExpectedResult32, result);
            }
        }

        [Test]
        [TestCaseSource("TestData")]
        public void Hash64_Stream_ReturnsExpectedValues(FnvTestVector data)
        {
            using (var stream = new MemoryStream(data.Buffer))
            {
                ulong result = Fnv1.Hash64(stream);
                Assert.AreEqual(data.ExpectedResult64, result);
            }
        }

        [Test]
        [TestCaseSource("TestData")]
        public void Hash32_ReturnsExpectedValues(FnvTestVector data)
        {
            uint result = Fnv1.Hash32(data.Buffer);
            Assert.AreEqual(data.ExpectedResult32, result);
        }

        [Test]
        [TestCaseSource("TestData")]
        public void Hash64_ReturnsExpectedValues(FnvTestVector data)
        {
            ulong result = Fnv1.Hash64(data.Buffer);
            Assert.AreEqual(data.ExpectedResult64, result);
        }
    }
}