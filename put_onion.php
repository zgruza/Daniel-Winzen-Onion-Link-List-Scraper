<?php
$servername = "localhost";
$username = "sql_username";
$password = "sql_password";
$dbname = "sql_database";


$onion = $_GET["onion"]; //<---- TEXT.ONION
$des = $_GET["des"]; //<---- TEXT.DESCRIPTION

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$sql = "INSERT INTO onions (onion, description)
VALUES ('$onion', '$des')";

if ($conn->query($sql) === TRUE) {
   echo "New record created successfully";


} else {
    echo "Creating post Error";

}



$conn->close();
?>