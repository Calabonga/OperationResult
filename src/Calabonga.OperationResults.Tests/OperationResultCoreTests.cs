using System;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace Calabonga.OperationResults.Tests
{
    /// <summary>
    /// OperationResultCore unit-tests
    /// 2019-07-18 11:22
    /// </summary>
    public class OperationResultCoreTests : IClassFixture<OperationResultCoreFixture>
    {
        private readonly OperationResultCoreFixture _fixture;

        public OperationResultCoreTests(OperationResultCoreFixture fixture)
        {
            _fixture = fixture;
        }


        [Fact]
        [Trait("OperationResult", "UnderTesting")]
        public void ItShould_be_under_testings()
        {
            // arrange
            var sut = _fixture.Create<int>();

            // act

            // assert
            Assert.NotNull(sut);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_to_Error_when_object_can_cast_to_it()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var customException = new CustomException(Messages.Title1);

            // act
            sut.AddError(customException);

            // assert
            Assert.NotNull(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_to_Error_when_object_null()
        {
            // arrange
            var sut = _fixture.Create<string>();

            // act
            sut.AddError(Messages.Title1);

            // assert
            Assert.Null(sut.Exception);
            Assert.NotNull(sut.Metadata.Message);
            Assert.Equal(Messages.Title1, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_to_Error_when_object_can_cast_to_it_and_use_title_as_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var customException = new CustomException(Messages.Title1);

            // act
            sut.AddError(customException);

            // assert
            Assert.NotNull(sut.Exception);
            Assert.NotNull(sut.Metadata.Message);
            Assert.Equal(Messages.Title1, sut.Metadata.Message);
            Assert.Equal(Messages.Title1, sut.Exception.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_to_Error_when_object_can_cast_to_it_and_use_title_as_message_with_metadata_error_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var customException = new CustomException(Messages.Title1);

            // act
            sut.AddError(customException);

            // assert
            Assert.Equal(Messages.Title1, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_to_metadata()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "test";
            // act
            sut.AddError(expected);

            // assert
            Assert.Equal(expected, sut.Metadata.Message);
            Assert.IsType<Metadata>(sut.Metadata);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_to_metadata_of_type_Error()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "test";
            // act
            sut.AddError(expected);

            // assert
            Assert.Equal(expected, sut.Metadata.Message);
            Assert.IsType<MetadataType>(sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_object_to_metadata_as_string()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "test";
            // act
            sut.AddError(new CustomException(expected));

            // assert
            Assert.IsType<string>(sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_message_to_metadata_as_string()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "test";
            // act
            sut.AddError(expected);

            // assert
            Assert.IsType<string>(sut.Metadata.Message);
            Assert.IsType<MetadataType>(sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_exception_message_to_metadata_as_string_with_metadataType()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "test";
            // act
            sut.AddError(expected);

            // assert
            Assert.IsType<string>(sut.Metadata.Message);
            Assert.Equal(MetadataType.Error, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_any_exception_type_to_Error_when_object_can_cast_to_it_and_use_title_as_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new Exception(Messages.Title1);

            // act
            sut.AddError(exception);

            // assert
            Assert.NotNull(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_error_message_with_exception()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new Exception(Messages.Title1);

            // act
            sut.AddError("TEST", exception);

            // assert
            Assert.NotNull(sut.Exception);
            Assert.NotNull(sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_Metadata_Message_should_be_equals_error_message()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<string>();
            var exception = new Exception(Messages.Title1);

            // act
            sut.AddError(expected, exception);

            // assert
            Assert.Equal(expected, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_add_any_exception_base_type()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new Exception(Messages.Title1);

            // act
            sut.AddError(exception);

            // assert
            Assert.Equal(Messages.Title1, sut.Exception.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_not_be_null()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new Exception();

            sut.AddError(exception);
            // act

            // assert
            Assert.NotNull(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_not_throw_error_when_message_not_defined()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new CustomException(null);

            // act
            sut.AddError(exception).AddData(Messages.Title1);

            // assert
            Assert.NotNull(sut.Exception);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Equal(Messages.Title1, sut.Metadata.DataObject.ToString());
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_throw_error_when_message_not_defined()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddError(exception);

            // assert
            Assert.NotNull(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddInfo")]
        public void ItShould_have_only_one_object_in_metadata_when_add_Info_with_Warning_added_before()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();
            var expected = exception.Message;

            // act
            sut.AddWarning(expected);
            sut.AddInfo(exception.ToString());


            // assert
            Assert.NotNull(sut.Metadata);
            Assert.Equal(MetadataType.Info, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddInfo")]
        public void ItShould_have_last_added_type_object_in_metadata()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();
            var expected = exception.Message;

            // act
            sut.AddWarning(expected);
            sut.AddInfo(exception.ToString());


            // assert
            Assert.NotNull(sut.Metadata);
            Assert.Equal(MetadataType.Info, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddInfo")]
        public void ItShould_have_only_one_object_in_metadata_when_add_Info_with_Error_added_before()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();
            var expected = exception.Message;

            // act
            sut.AddInfo(exception.ToString());
            sut.AddError(expected);

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.Equal(expected, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_exception_message_and_custom_message_when_added_both()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();
            var expected = exception.Message;

            // act
            sut.AddError(expected);

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.Equal(expected, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddInfo")]
        public void ItShould_have_able_to_add_DataObject_to_AddInfo()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = Messages.Title1;

            // act
            sut.AddInfo(data).AddData(data);

            var actual = sut.Metadata.Message;

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Equal(sut.Metadata.Message, actual);
        }

        [Fact]
        [Trait("OperationResult", "AddSuccess")]
        public void ItShould_have_able_to_add_DataObject_to_AddSuccess()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = Messages.Title1;

            // act
            sut.AddSuccess(data).AddData(data);

            var actual = sut.Metadata.Message;

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Equal(sut.Metadata.Message, actual);
        }


        [Fact]
        [Trait("OperationResult", "AddWarning")]
        public void ItShould_have_able_to_add_DataObject_to_AddWarning()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = Messages.Title1;

            // act
            sut.AddWarning(data).AddData(data);

            var actual = sut.Metadata.Message;

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Equal(sut.Metadata.Message, actual);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_able_to_add_DataObject_to_AddError()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = Messages.Title1;

            // act
            sut.AddError(data).AddData(data);

            var actual = sut.Metadata.Message;

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Equal(sut.Metadata.Message, actual);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_able_to_add_DataObject_Exception_after_AddError_should_have_Exception()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = new SimpleCustomException();

            // act
            sut.AddError(data).AddData(data);

            var actual = sut.Metadata.Message;

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Equal(sut.Exception.Message, actual);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_able_to_add_DataObject_Exception_after_AddError_should_have_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = new SimpleCustomException();

            // act
            sut.AddError(data).AddData(Messages.Title1);

            var actual = sut.Metadata.Message;

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.NotEqual(Messages.Title1, actual);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_able_to_add_DataObject_Exception_after_AddError_should_have_other_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception1 = new SimpleCustomException();
            var exception2 = new CustomException(Messages.Title1);

            // act
            sut.AddError(exception1).AddData(exception2);

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.NotNull(sut.Exception);

        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_able_to_add_DataObject_to_AddError_with_error_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = Messages.Title1;

            // act
            sut.AddError(data).AddData(data);

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Null(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddSuccess")]
        public void ItShould_have_able_to_add_DataObject_to_AddSuccess_after_AddInfo_and_last_should_saved()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var data = Messages.Title1;

            // act

            sut.AddInfo(data).AddData(data);
            sut.AddSuccess(data).AddData(data);

            var actual = sut.Metadata.Message;

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(sut.Metadata.DataObject);
            Assert.Equal(sut.Metadata.Message, actual);
        }

        [Fact]
        [Trait("OperationResult", "AddSuccess")]
        public void ItShould_have_only_one_object_in_metadata_when_add_Success()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddSuccess(exception.Message);

            // assert
            Assert.NotNull(sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddWarning")]
        public void ItShould_have_only_one_object_in_metadata_when_add_Warning()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddWarning(exception.ToString());

            // assert
            Assert.NotNull(sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_only_one_object_in_metadata_when_add_Error()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddError(exception);

            // assert
            Assert.NotNull(sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddInfo")]
        public void ItShould_have_string_type_for_metadata_Info()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddInfo(exception.ToString());

            // assert
            Assert.NotNull(sut.Metadata.Message);
            Assert.Equal(MetadataType.Info, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_string_type_for_metadata_Error()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddError(exception);

            // assert
            Assert.NotNull(sut.Metadata.Message);
            Assert.Equal(MetadataType.Error, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddSuccess")]
        public void ItShould_have_string_type_for_metadata_Success()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();


            // act
            sut.AddSuccess(exception.ToString());

            // assert
            Assert.Equal(MetadataType.Success, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddWarning")]
        public void ItShould_have_string_type_for_metadata_Warning()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();


            // act
            sut.AddWarning(exception.ToString());

            // assert
            Assert.Equal(MetadataType.Warning, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_string_type_for_metadata_DataObject()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddError(exception).AddData(exception);

            // assert
            Assert.NotNull(sut.Metadata.Message);
            Assert.IsType<SimpleCustomException>(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_equals_types_for_DataObject_and_Exception()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception = new SimpleCustomException();

            // act
            sut.AddError(exception).AddData(exception);

            // assert
            Assert.IsType<SimpleCustomException>(sut.Metadata.DataObject);
            Assert.IsType<SimpleCustomException>(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_not_have_equals_types_for_DataObject_and_Exception()
        {
            // arrange
            var sut = _fixture.Create<string>();
            var exception1 = new SimpleCustomException();
            var exception2 = new CustomException("TEST");

            // act
            sut.AddError(exception1).AddData(exception2);

            // assert
            Assert.IsType<CustomException>(sut.Metadata.DataObject);
            Assert.IsType<SimpleCustomException>(sut.Exception);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_not_have_message_equals_when_DataObject_added_and_Metadata_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "TEST";
            var exception1 = new SimpleCustomException();
            var exception2 = new CustomException(expected);

            // act
            sut.AddError(exception1).AddData(exception2);

            // assert
            Assert.NotEqual(expected, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_have_message_equals_when_DataObject_added_and_Metadata_message()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "THIS MESSAGE";
            var exception1 = new CustomException(expected);
            var exception2 = new CustomException("NOT THIS MESSAGE");

            // act
            sut.AddError(exception1).AddData(exception2);

            // assert
            Assert.Equal(expected, sut.Metadata.Message);
        }


        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_returns_GetMetadataMessages_message_from_exception()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "THIS MESSAGE";
            var exception1 = new CustomException(expected);
            var exception2 = new CustomException("NOT THIS MESSAGE");

            // act
            sut.AddError(exception1).AddData(exception2);
            var actual = sut.GetMetadataMessages();

            // assert
            Assert.Contains(expected, actual);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_not_returns_GetMetadataMessages_message_from_exception()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "THIS MESSAGE";
            const string notExpected = "NOT THIS MESSAGE";
            var exception1 = new CustomException(expected);
            var exception2 = new CustomException(notExpected);

            // act
            sut.AddError(exception1).AddData(exception2);
            var actual = sut.GetMetadataMessages();

            // assert
            Assert.NotEqual(notExpected, actual);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_serialize_to_string()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "THIS MESSAGE";
            sut.Result = expected;

            // act
            var data = JsonConvert.SerializeObject(sut);

            // assert
            Assert.NotNull(data);
            Assert.Contains(expected, data);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_deserialize_from_string()
        {
            // arrange
            var sut = _fixture.Create<string>();
            const string expected = "THIS MESSAGE";
            sut.Result = expected;

            // act
            var data = JsonConvert.SerializeObject(sut);
            var op = JsonConvert.DeserializeObject<OperationResult<string>>(data);

            // assert
            Assert.NotNull(op);
            Assert.Equal(op.Result, expected);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_deserialize_from_object()
        {
            // arrange
            var sut = _fixture.Create<Person>();
            sut.Result = new Person { FirstName = "Test", LastName = "Test" };


            // act
            var data = JsonConvert.SerializeObject(sut);
            var op = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(op);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_deserialize_from_object_with_metadata()
        {
            // arrange
            var sut = _fixture.Create<Person>();
            sut.Result = new Person { FirstName = "Test", LastName = "Test" };
            sut.AddInfo("Message Info");


            // act
            var data = JsonConvert.SerializeObject(sut);
            var op = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(op);
            Assert.Equal(MetadataType.Info, sut.Metadata.Type);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_deserialize_from_object_with_metadata_with_message()
        {
            // arrange
            var sut = _fixture.Create<Person>();
            sut.Result = new Person { FirstName = "Test", LastName = "Test" };
            sut.AddInfo("Message Info");


            // act
            var data = JsonConvert.SerializeObject(sut);
            var op = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(op);
            Assert.NotNull(sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_deserialize_from_object_with_metadata_with_message_success()
        {
            // arrange
            var sut = _fixture.Create<Person>();
            const string expected = "THIS MESSAGE";
            sut.Result = new Person { FirstName = "Test", LastName = "Test" };
            sut.AddSuccess(expected);


            // act
            var data = JsonConvert.SerializeObject(sut);
            var op = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(op);
            Assert.Equal(MetadataType.Success, sut.Metadata.Type);
            Assert.Equal(expected, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_deserialize_from_object_with_metadata_with_message_error()
        {
            // arrange
            var sut = _fixture.Create<Person>();
            const string expected = "THIS MESSAGE";
            sut.Result = new Person { FirstName = "Test", LastName = "Test" };
            sut.AddError(new CustomException(expected));


            // act
            var data = JsonConvert.SerializeObject(sut);
            var op = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(op);
            Assert.Equal(MetadataType.Error, sut.Metadata.Type);
            Assert.Equal(expected, sut.Metadata.Message);
        }

        [Fact]
        [Trait("OperationResult", "SerializeObject")]
        public void ItShould_deserialize_from_object_with_metadata_with_message_not_success()
        {
            // arrange
            var sut = _fixture.Create<Person>();
            const string expected = "THIS MESSAGE";
            sut.Result = new Person { FirstName = "Test", LastName = "Test" };
            sut.AddError(new CustomException(expected)).AddData(new SimpleCustomException());

            // act
            var data = JsonConvert.SerializeObject(sut);
            var op = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(sut.Metadata);
            Assert.NotNull(op);
            Assert.NotEqual(MetadataType.Success, sut.Metadata.Type);
            Assert.Equal(expected, sut.Metadata.Message);
            Assert.NotNull(op.Metadata);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_have_internal_logger_with_appendLog_method()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expected);
            var actual = sut.Logs.Single(x => x.Contains(expected));

            // assert
            Assert.Contains(expected, actual);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_have_internal_logger_with_appendLog_method_not_creared_after_addInfo()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expected);
            sut.AddInfo(expected);
            var actual = sut.Logs.Count(x => x.Contains(expected));

            // assert
            Assert.Equal(2, actual);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_have_append_null_message()
        {
            // arrange
            const string expected = null;
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expected);
            var message = sut.Logs.Count();

            // assert
            Assert.Equal(0, message);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_not_append_Info_to_logger()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expected);
            sut.AddInfo(expected);
            var actual = sut.Logs.Count();

            // assert
            Assert.Equal(2, actual);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_not_append_Info_to_logger_and_keep_Info()
        {
            // arrange
            const string expected = "TEST";
            const string expected1 = "TEST1";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expected1);
            sut.AddInfo(expected);
            var actual = sut.Logs.Count();

            // assert
            Assert.Equal(2, actual);
            Assert.NotEqual(expected1, sut.GetMetadataMessages());
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_append_Info_to_logger_and_keep_Info()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expected);
            sut.AddInfo(expected);
            var actual = sut.Logs.Count();
            var isContains = sut.GetMetadataMessages().Contains(expected);

            // assert
            Assert.Equal(2, actual);
            Assert.True(isContains);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_return_info_with_logs_for_GetMetadataMessages()
        {
            // arrange
            const string expectedText = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expectedText);
            sut.AddInfo(expectedText);
            var actual = sut.Logs.Count();

            // assert
            Assert.Equal(2, actual);
            Assert.Contains(expectedText, sut.GetMetadataMessages());
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_cut_message_when_log_adding_to_500()
        {
            // arrange
            const string expected = "TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG_TEST_LONG_LONG_TEXT_LONG";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expected);
            var length = sut.Logs.First().Length;

            // assert
            Assert.Equal(500, length);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_return_info_with_logs_for_GetMetadataMessages_by_mode_MessageWithLogs_and_Logs()
        {
            // arrange
            const string expectedText1 = "TEST1";
            const string expectedText2 = "TEST2";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expectedText1);
            sut.AddInfo(expectedText2);
            var actual = sut.GetMetadataMessages().Contains(expectedText1);

            // assert
            Assert.True(actual);
            Assert.Equal(2, sut.Logs.Count());
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_Serialize_Logs()
        {
            // arrange
            const string expectedText1 = "TEST1";
            const string expectedText2 = "TEST2";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expectedText1);
            sut.AppendLog(expectedText2);
            var data = JsonConvert.SerializeObject(sut);
            var deserializeObject = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(deserializeObject);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_Serialize_Logs_with_data()
        {
            // arrange
            const string expectedText1 = "TEST1";
            const string expectedText2 = "TEST2";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expectedText1);
            sut.AppendLog(expectedText2);
            var data = JsonConvert.SerializeObject(sut);
            var deserializeObject = JsonConvert.DeserializeObject<OperationResult<Person>>(data);

            // assert
            Assert.NotNull(deserializeObject.Logs);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_Serialize_Logs_with_data_count_2()
        {
            // arrange
            const int expected = 2;
            const string expectedText1 = "TEST1";
            const string expectedText2 = "TEST2";
            var sut = _fixture.Create<Person>();

            // act
            sut.AppendLog(expectedText1);
            sut.AppendLog(expectedText2);
            var data = JsonConvert.SerializeObject(sut);
            var deserializeObject = JsonConvert.DeserializeObject<OperationResult<Person>>(data);
            var actual = deserializeObject.Logs.Count();

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_appendLog_when_addError()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.AddError(expected);
            var exists = sut.Logs.Single(x => x.Contains(expected));

            // assert
            Assert.NotNull(exists);
        }

        [Fact]
        [Trait("OperationResult", "AddError")]
        public void ItShould_Exception_for_addError_and_Message()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.AddError(expected, new SimpleCustomException());
            
            // assert
            Assert.NotNull(sut.Exception);
            Assert.NotNull(sut.Metadata);
        }

        [Fact]
        [Trait("OperationResult", "ActivityId")]
        public void ItShould_have_ActivityId_can_set()
        {
            // arrange
            const string expected = "TEST";
            var sut = _fixture.Create<Person>();

            // act
            sut.ActivityId = expected;
            
            // assert
            Assert.Equal(expected, sut.ActivityId);
        }

        [Fact]
        [Trait("OperationResult", "ActivityId")]
        public void ItShould_have_ActivityId_predefined()
        {
            // arrange
            var sut = _fixture.Create<Person>();

            // act
            
            // assert
            Assert.NotNull(sut.ActivityId);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_Serialize_ActivityId_and_deserialize_another()
        {
            // arrange
            const string expectedText1 = "TEST1";
            var sut = _fixture.Create<Person>();
            var expected = sut.ActivityId;

            // act
            sut.AppendLog(expectedText1);
            var data = JsonConvert.SerializeObject(sut);
            var deserializeObject = JsonConvert.DeserializeObject<OperationResult<Person>>(data);
            var actual = deserializeObject.ActivityId;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        [Trait("OperationResult", "AppendLog")]
        public void ItShould_Serialize_ActivityId()
        {
            // arrange
            const string expectedText1 = "TEST1";
            var sut = _fixture.Create<Person>();
            var expected = sut.ActivityId;

            // act
            sut.AppendLog(expectedText1);
            var data = JsonConvert.SerializeObject(sut);

            // assert
            Assert.Contains(expected, data);
        }
    }
}
