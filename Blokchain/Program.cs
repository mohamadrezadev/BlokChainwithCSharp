// See https://aka.ms/new-console-template for more information
using Blokchain;

Console.WriteLine("Hello, World!");
// **************************************************
var dariushTasdighiAccount =
    new Account( )
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


//var contract =new Contract(initialDifficulty: 1);

//var contract =
//	new Contract(initialDifficulty: 2);

var contract =
    new Contract();
    new Contract(initialDifficulty: 3);
// **************************************************


// **************************************************
var transaction1 =
    new Transaction( amount: 10,
    recipientAccountAddress: dariushTasdighiAccount.Address);

contract.AddTransactionAndMineBlock(transaction: transaction1);
// **************************************************

// **************************************************
var transaction2 =
    new Transaction( amount: 20,

    senderAccountAddress: aliRezaAlaviAccount.Address.ToString(),
    recipientAccountAddress: dariushTasdighiAccount.Address);

contract.AddTransactionAndMineBlock(transaction: transaction2);
// **************************************************

// **************************************************
var transaction3 =
    new Transaction( amount: 5,
    senderAccountAddress: dariushTasdighiAccount.Address,
    recipientAccountAddress: saraAhmadiAccount.Address);

contract.AddTransactionAndMineBlock(transaction: transaction3);
// **************************************************

System.Console.WriteLine(contract);

// **************************************************
float dariushTasdighiBalance =
    contract.GetAccountBalance
    (accountAddress: dariushTasdighiAccount.Address);

System.Console.WriteLine
    ($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");


// **************************************************
// **************************************************
transaction2.Amount = 100;
// **************************************************

// **************************************************
dariushTasdighiBalance =
    contract.GetAccountBalance
    (accountAddress: dariushTasdighiAccount.Address);

System.Console.WriteLine
    ($"{dariushTasdighiAccount.FullName} Balance: {dariushTasdighiBalance}");
// **************************************************