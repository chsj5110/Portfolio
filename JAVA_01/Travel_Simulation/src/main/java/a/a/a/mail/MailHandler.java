package a.a.a.mail;

import java.io.File;
import java.io.UnsupportedEncodingException;

import javax.mail.MessagingException;
import javax.mail.internet.MimeMessage;
import javax.sql.DataSource;

import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.MimeMessageHelper;

public class MailHandler { // 메일보내기 유틸 클래스
	private JavaMailSender mailSender;
	private MimeMessage message;
	private MimeMessageHelper messageHelper;

	public MailHandler(JavaMailSender mailSender) throws MessagingException {
		this.mailSender = mailSender;
		message = this.mailSender.createMimeMessage();
		messageHelper = new MimeMessageHelper(message, true, "UTF-8");
	}

	public void setSubject(String subject) throws MessagingException {
		messageHelper.setSubject(subject);
	}

	public void setText(String htmlContent) throws MessagingException {
		messageHelper.setText(htmlContent, true);
	}

	public void setFrom(String email, String name) throws UnsupportedEncodingException, MessagingException {
		messageHelper.setFrom(email, name);
	}

	public void setTo(String email) throws MessagingException {
		messageHelper.setTo(email);	
	}

	public void addInline(String contentId, DataSource dataSource) throws MessagingException {
		messageHelper.addInline(contentId, dataSource);
	}

	public void send() {
		mailSender.send(message);
	}

	public void addInline(String contentId, File file) throws MessagingException {
		messageHelper.addInline(contentId, file);
		// TODO Auto-generated method stub
		
	}


}