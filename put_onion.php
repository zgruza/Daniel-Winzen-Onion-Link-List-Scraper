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

$setup = "CREATE TABLE `onions` (
  `id` int(11) NOT NULL,
  `onion` text COLLATE utf8_unicode_ci NOT NULL DEFAULT 0,
  `description` text COLLATE utf8_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci";

$sql = "INSERT INTO onions (onion, description)
VALUES ('$onion', '$des')";

if(isset($_GET['setup']) && isset($_GET['setup'])){
	if ($conn->query($setup) === TRUE) {
	   echo "Setup database is successfully installed!<br />Now run C# Code. :) ";
	} else {
	    echo "Database Connection Error! Change credetains and try it again.";

	}
}

if ($conn->query($sql) === TRUE) {
   echo "New record created successfully";


} else {
    echo "Creating post Error";

}



$conn->close();
?>