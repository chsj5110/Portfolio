package a.a.a.impl;

import java.sql.SQLException;
import java.util.HashMap;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.core.io.ClassPathResource;
import org.springframework.mail.javamail.JavaMailSender;
import org.springframework.mail.javamail.JavaMailSenderImpl;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import a.a.a.ctr.MailController;
import a.a.a.dao.MailDAO;
import a.a.a.dao.MembershipDAO;
import a.a.a.mail.MailHandler;
import a.a.a.mail.TempKey;
import a.a.a.service.MailService;



@Service("mailService")
public class MailImpl implements MailService{
	
	@Autowired
	private JavaMailSenderImpl mailSender;
	
	@Autowired
	BCryptPasswordEncoder passwordEncoder;

	private static final Logger logger = LoggerFactory.getLogger(MailImpl.class);

	
	@Resource(name="mailDAO")
    private MailDAO mailDAO;
	
	@Transactional
	
	//인증키 생성
	@Override
	public void createAuthKey(String userEmail, String authKey) throws Exception {
		String key = new TempKey().getKey(8, false); // 인증키 생성
		String encodeKey = passwordEncoder.encode(key); //인증키 암호화
		mailDAO.createAuthKey(userEmail, encodeKey); // 인증키 DB저장
		logger.info("메일전송 시작");
		MailHandler sendMail = new MailHandler(mailSender);
		sendMail.setSubject("[홈페이지 이메일 인증]"); // 메일제목
		sendMail.setText( // 메일내용
				"<h1>메일인증</h1>" +
				"<h2>인증키는"+ key+"</h2>");
		sendMail.setFrom("TravelSimulation@gmail.com", "여행시뮬레이션"); // 보낸이
		sendMail.setTo(userEmail); // 받는이
		sendMail.send();

	}
	
	//인증키 다시 생성
	@Override
	public void updateAuthKey(String userEmail, String authKey) throws Exception {
		String key = new TempKey().getKey(8, false); // 인증키 생성
		String encodeKey = passwordEncoder.encode(key); //인증키 암호화
		mailDAO.updateAuthKey(userEmail, encodeKey); // 인증키 DB저장
		logger.info("메일전송 시작");
		MailHandler sendMail = new MailHandler(mailSender);
		sendMail.setSubject("[홈페이지 이메일 인증]"); // 메일제목
		

		
		sendMail.setText( // 메일내용
				"<img src='cid:img'>"+
				"<h1>메일인증</h1>" +
				"<h2>인증키는"+ key+"</h2>");
		sendMail.setFrom("TravelSimulation@gmail.com", "여행시뮬레이션"); // 보낸이
		
		
		/*
		 * ClassPathResource resource = new ClassPathResource("gif/chika.gif");
		 * sendMail.addInline("img", resource.getFile());
		 */

		
		
		sendMail.setTo(userEmail); // 받는이
		sendMail.send();

	}
	
	//해당 이메일로 가입된 회원이 있는지 확인
	@Override
	public boolean emailCheck(HashMap<String, Object> hm) throws Exception{
		
		logger.info("cnt는"+ Integer.parseInt(mailDAO.emailCheck(hm).get("CNT").toString()));
		int i = Integer.parseInt(mailDAO.emailCheck(hm).get("CNT").toString());
		boolean bol = false;

		if (i != 0) {
			bol = true;
		} else {
			bol = false;
		}

		return bol;
	}
	
	//해당 이메일로 인증키가 생성된적 있는지 확인
	@Override
	public boolean emailCheck2(HashMap<String, Object> hm) throws Exception{
		
		logger.info("cnt는"+ Integer.parseInt(mailDAO.emailCheck2(hm).get("CNT").toString()));
		int i = Integer.parseInt(mailDAO.emailCheck2(hm).get("CNT").toString());
		boolean bol = false;

		if (i != 0) {
			bol = true;
		} else {
			bol = false;
		}

		return bol;
	}
	
	
	//인증키가 맞는지 확인
	@Override
	public String authKeyCheck(HashMap<String, Object> hm) throws Exception{
		
		String encodeKey = mailDAO.authKeyCheck(hm).get("AUTH_KEY").toString();

		return encodeKey;
	}
	
	    
}
