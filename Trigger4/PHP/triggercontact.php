<?php

session_start();

require_once 'libs/phpmailer/PHPMailerAutoload.php';

$errors = array();

if(isset($_POST['email'], $_POST['message'])){
	$fields = array(
		'email' => $_POST['email'],
		'message' => $_POST['message']
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
		$m->Subject = 'Contact Form from Trigger Find';
		$m->Body = 'From: ' . $fields['email'] . '<p>' . $fields['message'] . '</p>';
		
		$m->FromName = 'Contact';
		
		$m->AddAddress('contact@triggerfind.com', 'Contact Form');
		
		if($m->send()) {
			header( 'Location: main.aspx' ) ;
		} else {
			echo 'Error with contact form.  Press back and try again later';
		}
	}
	
} else {
	echo 'Error with contact form.  Press back and try again later';
}

?>