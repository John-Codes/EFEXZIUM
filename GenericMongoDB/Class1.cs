using MongoDB.Driver;
using System;

namespace GenericMongoDB
{
    public class MongoInit
    {

        private static readonly string ConnectionString = "Blank";
        private static readonly string DbName = "GenericDB";

        private IMongoDatabase db;

        public MongoInit(IConfiguration)
        {

            var client = new MongoClient(ConnectionString);

            db = client.GetDatabase(DbName);

        }



        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);

            collection.InsertOne(record);

        }

        public List<T> GetALLRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();

        }

        public List<T> GetAllStoresWhereUserIsAssigned<T>(string table, Guid id)
        {

            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("IDTienda", id);

            var result = collection.Find(filter).ToList();

            return result;

        }
        public List<T> GetAllStoresByStoreID<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("IDTienda", id);

            var result = collection.Find(filter).ToList();

            return result;

        }

        public List<T> GetAllEmployeesbyid<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("StoreID", id);

            var result = collection.Find(filter).ToList();

            return result;

        }

        public List<T> GetAllRecordsByStoreID<T>(string table, Guid id)
        {

            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("StoreID", id);

            var result = collection.Find(filter).ToList();

            return result;



        }

        public List<T> GetAllEmployees<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("isemployee", true);

            var result = collection.Find(filter).ToList();
            return result;

        }



        public T GetRecordByID<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);


            return collection.Find(filter).First();



        }

        public T GetProductoByIDOrNULL<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("StoreID", id);


            return collection.Find(filter).FirstOrDefault();



        }
        public T GetAllByID<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("StoreID", id);


            return collection.Find(filter).FirstOrDefault();



        }
        public T GetByEmail<T>(string table, string email)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Email", email);


            return collection.Find(filter).FirstOrDefault();



        }
        public T GetByID<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);


            return collection.Find(filter).FirstOrDefault();



        }
        public T GetbystoreID<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);


            return collection.Find(filter).FirstOrDefault();



        }
        public T GetByTempID<T>(string table, string id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("TempID", id);


            return collection.Find(filter).FirstOrDefault();



        }


        public T CheckStoreSaved<T>(string table, Store store)
        {
            var collection = db.GetCollection<T>(table);
            var filter1 = Builders<T>.Filter.Eq("Pueblo", store.Pueblo);
            var filter2 = Builders<T>.Filter.Eq("Calle", store.Calle);
            var Filter = Builders<T>.Filter.And(filter1, filter2);

            //todo: cant get any record even when the ID matches
            return collection.Find(Filter).FirstOrDefault();

        }


        //public T Login<T>(string table, string email, string password)
        //{
        //    var collection = db.GetCollection<T>(table);
        //    var filter1 = Builders<T>.Filter.Eq("Email", email );
        //    var filter2 = Builders<T>.Filter.Eq("Password", password);
        //    var Filter = Builders<T>.Filter.And(filter1, filter2);


        //    return collection.Find(Filter).First();

        //}
        public T Login<T>(string table, UsuarioDT usuario)
        {
            var collection = db.GetCollection<T>(table);
            var filter1 = Builders<T>.Filter.Eq("Email", usuario.Email);
            var filter2 = Builders<T>.Filter.Eq("Password", usuario.Password);
            var Filter = Builders<T>.Filter.And(filter1, filter2);


            return collection.Find(Filter).First();

        }
        public T Login2<T>(string table, Usuario cred)
        {
            var collection = db.GetCollection<T>(table);
            var filter1 = Builders<T>.Filter.Eq("email", cred.Email);
            var filter2 = Builders<T>.Filter.Eq("password", cred.Password);
            var Filter = Builders<T>.Filter.And(filter1);


            var a = collection.Find(Filter).FirstOrDefault();
            return a;

        }


        //Inserts or Update
        public void UpsertRecord<T>(string table, Guid ID, T record)
        {
            var collection = db.GetCollection<T>(table);

            //If true and no record macthes ID, The record will be inserted.
            var result = collection.ReplaceOne(
                new BsonDocument("_id", ID),
                record,

                new UpdateOptions { IsUpsert = true }



                );


        }
        //public void UpdateUserSessionDuration<T>(string table, Guid ID, int duration)
        //{

        //    var collection = db.GetCollection<T>(table);

        //    var filter = Builders<T>.Filter.Eq("IDTienda", producto.StoreID);
        //    var update = Builders<T>.Update.Set("Producto", producto);
        //    var result = collection.UpdateOne(filter, update);
        //    //todo test this



        //}
        public void UpdateProducto<T>(string table, Guid ID, Producto producto)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("IDTienda", producto.StoreID);
            var update = Builders<T>.Update.Set("Producto", producto);
            var result = collection.UpdateOne(filter, update);
            //todo test this



        }
        public T UpdateUserLogIn<T>(string table, Guid ID, Usuario user)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", user.Id);
            var update = Builders<T>.Update.Set("IsLoggedIn", user.IsLoggedIn);
            collection.UpdateOne(filter, update);

            return collection.Find(filter).FirstOrDefault();
            //todo test this



        }
        public T ValidEmail<T>(string table, Guid ID, Usuario user)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", user.Id);
            var update = Builders<T>.Update.Set("ValidEMail", user.ValidEMail);
            collection.UpdateOne(filter, update);

            return collection.Find(filter).FirstOrDefault();
            //todo test this



        }
        public T UpdatePW<T>(string table, Guid ID, Usuario user)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", user.Id);
            var update = Builders<T>.Update.Set("password", user.Password);

            collection.UpdateOne(filter, update);

            return collection.Find(filter).FirstOrDefault();
            //todo test this



        }
        public T UpdateTempID<T>(string table, Guid ID, Usuario user)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", user.Id);

            var update = Builders<T>.Update.Set("TempID", user.TempIDAccesForPWReset);

            collection.UpdateOne(filter, update);

            return collection.Find(filter).FirstOrDefault();
            //todo test this



        }
        public bool UpdateItem<T>(string table, Guid ID, T Item, string ItemsIDName)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq($"{ItemsIDName}", ID);
            var olditem = collection.Find(filter);
            if (olditem != null)
            {
                collection.DeleteOne(filter);

                collection.InsertOne(Item);
                return true;
            }
            return false;
            //todo test this



        }
        //todo just use a simple one object  table forget the MenuTienda Class
        //or https://www.thecodebuzz.com/mongodb-add-update-field-to-document-in-mongodb-collection/
        //public void UpdateRecordOrAdd<T>(string table, Guid ID, T record)
        //    {
        //        var collection = db.GetCollection<T>(table);

        //    var update = Builders<BsonDocument>.Update.Set("MenuTienda", record);
        //    var filter = Builders<BsonDocument>.Filter.Eq("_id", ID);

        //    var options = new UpdateOptions { IsUpsert = true };

        //    collection.UpdateOne(filter, update, options);
        //    }

        public void Delete2UpdateMenu<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("IDTienda", id);
            collection.DeleteOne(filter);
        }

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }
        public void DeleteOrdersFromAStoreInCart<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("StoreID", id);
            collection.DeleteMany(filter);
        }


    }
}
