// See https://aka.ms/new-console-template for more information
using Blokchain;
using System.Transactions;
using Transaction = Blokchain.Transaction;

Console.WriteLine("Hello, World!");
//// **************************************************
//var mohamadrezakiani =
//    new Account( )
//    {
//        FullName = "mohmadreza kiani",
//    };

//var omidhadidi =
//    new Account()
//    {
//        FullName = "omid hadidi",
//    };

//var aliImeni =
//    new Account()
//    {
//        FullName = "ali Imeni",
//    };
//// **************************************************


////var contract =new Contract(initialDifficulty: 1);

////var contract =
////	new Contract(initialDifficulty: 2);

//var contract =

//    new Contract(initialDifficulty: 0);
//// **************************************************
//Transaction transaction;
//// **************************************************
//transaction =
//    new Transaction(amount: 10,
//    type: TransactionType.Charging,
//    recipientAccountAddress: mohamadrezakiani.Address);

//contract.AddTransaction(transaction);
//// **************************************************

//// **************************************************
//transaction =
//    new Transaction(amount: 50,
//    type: TransactionType.Charging,
//    recipientAccountAddress: omidhadidi.Address);

//contract.AddTransaction(transaction);
//// **************************************************

//// **************************************************
//transaction =
//    new Transaction(amount: 20,
//    type: TransactionType.Transferring,
//    senderAccountAddress: omidhadidi.Address,
//    recipientAccountAddress: aliImeni.Address);

//contract.AddTransaction(transaction);
//// **************************************************

//// **************************************************
//transaction =
//    new Transaction(amount: 5,
//    type: TransactionType.Transferring,
//    senderAccountAddress: mohamadrezakiani.Address,
//    recipientAccountAddress: aliImeni.Address);

//contract.AddTransaction(transaction);
//// **************************************************
//Console.WriteLine(contract);
//// **************************************************
//float dariushTasdighiBalance =
//    contract.GetAccountBalance
//    (accountAddress: mohamadrezakiani.Address);

//Console.WriteLine($"{mohamadrezakiani.FullName} Balance: {dariushTasdighiBalance}");
//// **************************************************
//Console.WriteLine(contract);

//float mohamadrezakianiBalance =
//        contract.GetAccountBalance(accountAddress: mohamadrezakiani.Address);

//Console.WriteLine($"{mohamadrezakiani.FullName} Balance: {mohamadrezakianiBalance}");

// **************************************************
var dariushTasdighiAccount =
    new Account()
    {
        FullName = "Dariush Tasdighi",
    };

var aliRezaAlaviAccount =
    new Account()
    {
        FullName = "Ali Reza Alavi",
    };

var saraAhmadiAccount =
    new Account()
    {
        FullName = "Sara Ahmadi",
    };
// **************************************************

var contract =
    new Contract(initialDifficulty: 2);

Transaction transaction;

// ************************************************** 
var transaction1  =
    new Transaction(amount: 10,
    type: TransactionType.Charging,
    recipientAccountAddress: dariushTasdighiAccount.Address);

contract.AddTransaction(transaction1);
// **************************************************

// **************************************************
var transaction2 =
    new Transaction(amount: 50,
    type: TransactionType.Charging,
    recipientAccountAddress: aliRezaAlaviAccount.Address);

contract.AddTransaction(transaction2);
// **************************************************

// **************************************************
var transaction3 =
    new Transaction(amount: 20,
    type: TransactionType.Transferring,
    senderAccountAddress: aliRezaAlaviAccount.Address,
    recipientAccountAddress: dariushTasdighiAccount.Address);

contract.AddTransaction(transaction3);
// **************************************************

// **************************************************
var transaction4 =
    new Transaction(amount: 5,
    type: TransactionType.Transferring,
    senderAccountAddress: dariushTasdighiAccount.Address,
    recipientAccountAddress: saraAhmadiAccount.Address);

contract.AddTransaction(transaction4);
// **************************************************

// **************************************************
// Step (1)
// **************************************************
Console.WriteLine(contract);

float dariushTasdighiBalance =
    contract.GetAccountBalance
    (accountAddress: dariushTasdighiAccount.Address);

System.Console.WriteLine
    ($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
// **************************************************
