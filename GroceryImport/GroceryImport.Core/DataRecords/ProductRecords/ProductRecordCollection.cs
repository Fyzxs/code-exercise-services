using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GroceryImport.Core.DataRecords.ProductRecords
{
    public abstract class ProductRecordCollection : IEnumerable<ProductRecord>
    {
        /*
            It's likely the case that more robust collection/enumeration structures will be more appropriate as a general solution.
            Or implementing a custom iterator that has a Reset method.

            I don't know... yet.
         */

        private readonly StreamReader _streamReader;
        private readonly IProductRecordFactory _factory;
        private readonly IInputRecordValidator _validator;

        protected ProductRecordCollection(StreamReader streamReader, IProductRecordFactory factory, IInputRecordValidator validator)
        {
            _streamReader = streamReader;
            _factory = factory;
            _validator = validator;
        }
        
        public IEnumerator<ProductRecord> GetEnumerator()
        {
            string record;
            while (null != (record = _streamReader.ReadLine()))
            {
                if (_validator.NotValidFormat(record)) continue;

                yield return _factory.Create(record);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}