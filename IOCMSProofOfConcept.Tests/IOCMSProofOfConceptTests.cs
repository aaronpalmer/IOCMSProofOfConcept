using System;
using System.Linq;
using System.Transactions;
using IOCMSProofOfConcept.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IOCMSProofOfConcept.Tests
{
    [TestClass]
    public class IOCMSProofOfConceptTests
    {

        private const string Name = "Entity - New Name";
        private const string Description = "Entity - New Description";

        private static InitialClassification NewInitialClassification { get; set; }
        private static TempClassification NewTempClassification { get; set; }

        [TestMethod]
        public void TransactionScope_GoodSaveChanges_SavesData()
        {
            // Arrange
            NewInitialClassification = new InitialClassification { Name = Name, Description = Description };
            NewTempClassification = new TempClassification { Name = Name, Description = Description };

            // Act
            using (var transaction = new TransactionScope())
            {
                using (var entities = new IOCMSProofOfConceptEntities())
                {
                    // insert some data
                    entities.InitialClassifications.Add(NewInitialClassification);

                    entities.SaveChanges();

                    // insert some data based on results of previous proc call
                    NewTempClassification.Name = String.Format("{0}-{1}", Name, NewInitialClassification.Id);
                    entities.TempClassifications.Add(NewTempClassification);

                    entities.SaveChanges();

                }
                transaction.Complete();
            }

            // Assert
            using (var entities = new IOCMSProofOfConceptEntities())
            {
                // !! this syntax requires that the entity be mapped to a view
                //var actualInitial = entities.InitialClassifications.First(x => x.Id == NewInitialClassification.Id);

                var actualInitial = entities.uspInitialClassifications_Get(NewInitialClassification.Id).First();
                Assert.AreEqual(Name, actualInitial.Name);
                Assert.AreEqual(Description, actualInitial.Description);

                // !! this syntax requires that the entity be mapped to a view
                //var actualTemp = entities.InitialClassifications.First(x => x.Id == NewTempClassification.Id);

                var actualTemp = entities.uspTempClassifications_Get(NewTempClassification.Id).First();
                Assert.AreEqual(String.Format("{0}-{1}", Name, actualInitial.Id), actualTemp.Name);
                Assert.AreEqual(Description, actualTemp.Description);
            }
        }

        [TestMethod]
        public void TransactionScope_NoSaveChanges_Rollsback()
        {
            // Arrange
            NewInitialClassification = new InitialClassification { Name = Name, Description = Description };
            NewTempClassification = new TempClassification { Name = Name, Description = Description };

            // Act
            using (var transaction = new TransactionScope())
            {
                using (var entities = new IOCMSProofOfConceptEntities())
                {
                    // insert some data
                    entities.InitialClassifications.Add(NewInitialClassification);

                    // insert some data based on results of previous proc call
                    NewTempClassification.Name = String.Format("{0}-{1}", Name, NewInitialClassification.Id);
                    entities.TempClassifications.Add(NewTempClassification);

                    // rollback
                    //entities.SaveChanges();
                }
                transaction.Complete();
            }

            // Assert
            // verify that the values did not save
            Assert.AreEqual(0, NewInitialClassification.Id);
            Assert.AreEqual(0, NewTempClassification.Id);
        }

        [TestMethod]
        public void TransactionScope_BadSaveChanges_DoesNotSaveDataCorrectly()
        {
            // Arrange
            NewInitialClassification = new InitialClassification { Name = Name, Description = Description };
            NewTempClassification = new TempClassification { Name = Name, Description = Description };

            // Act
            using (var transaction = new TransactionScope())
            {
                using (var entities = new IOCMSProofOfConceptEntities())
                {
                    // insert some data
                    entities.InitialClassifications.Add(NewInitialClassification);

                    // insert some data based on results of previous proc call
                    NewTempClassification.Name = String.Format("{0}-{1}", Name, NewInitialClassification.Id);
                    entities.TempClassifications.Add(NewTempClassification);

                    entities.SaveChanges();

                }
                transaction.Complete();
            }

            // Assert
            using (var entities = new IOCMSProofOfConceptEntities())
            {
                // the first record inserted will be good data
                var actualInitial = entities.uspInitialClassifications_Get(NewInitialClassification.Id).First();
                Assert.AreEqual(Name, actualInitial.Name);
                Assert.AreEqual(Description, actualInitial.Description);

                // the second record will be bad because it was based on saved data from the first
                var actualTemp = entities.uspTempClassifications_Get(NewTempClassification.Id).First();
                var actualInitialId = 0; // now it's 0 instead of the actualInitial.Id
                Assert.AreEqual(String.Format("{0}-{1}", Name, actualInitialId), actualTemp.Name);
                Assert.AreEqual(Description, actualTemp.Description);
            }
        }
    }
}
