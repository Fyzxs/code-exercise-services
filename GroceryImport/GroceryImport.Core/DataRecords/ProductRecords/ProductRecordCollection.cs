using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace GroceryImport.Core.DataRecords.ProductRecords
{
    /// <summary>
    /// An Enumerable Collection of <see cref="ProductRecord"/> objects
    /// </summary>
    public abstract class ProductRecordCollection : IEnumerable<ProductRecord>
    {
        /*
            It's likely the case that more robust collection/enumeration structures will be more appropriate as a general solution.
            Or implementing a custom iterator...

            I don't know... yet.
         */

        //TODO: Create a Bookend around StreamReader. This is tight coupling to 3rd Party code.
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
            //TODO: No Nulls! This needs to be gone. Likely into the StreamReaderBookEnd
            while (null != (record = _streamReader.ReadLine()))
            {
                if (_validator.Invalid(record)) continue;

                yield return _factory.Create(record);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}