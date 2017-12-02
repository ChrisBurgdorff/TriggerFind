<?php

session_start();

require_once 'libs/phpmailer/PHPMailerAutoload.php';

$errors = array();

if(isset($_POST['emaillist'])){
	$fields = array(
		'emaillist' => $_POST['emaillist'],
	);
	
	foreach($fields as $field => $data) {
		if(empty($data)) {
			echo 'All Fields are required, please press back and try again.';
		}
	}
	
	if(empty($errors)) {
		
		$m = new PHPMailer;
		
		$m->isSMTP();
		$m->SMTPAuth = true;
		$m->Host = 'smtp.gmail.com';
		$m->Username = 'christopherburgdorff@gmail.com';
		$m->Password = 'vcr357';
		$m->SMTPSecure = 'ssl';
		$m->Port = 465;
		$m->isHTML();
		$m->Subject = 'Mailing List Signup from Trigger Find';
		$m->Body = 'From: ' . $fields['emaillist'];
		
		$m->FromName = 'Contact';
		
		$m->AddAddress('christopherburgdorff@gmail.com', 'Chris Burgdorff');
		
		if($m->send()) {
			header( 'Location: index.html' ) ;
		} else {
			echo 'Error with email list.  Press back and try again later';
		}
	}
	
} else {
	echo 'Error with contact form.  Press back and try again later';
}

?>