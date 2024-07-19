package a.a.a.service;

import java.util.HashMap;

import org.springframework.transaction.annotation.Transactional;

import a.a.a.dao.MailDAO;
import a.a.a.mail.MailHandler;
import a.a.a.mail.TempKey;

public interface MailService {

	public void createAuthKey(String userEmail, String authKey) throws Exception;
	
	public void updateAuthKey(String userEmail, String authKey) throws Exception;

	public boolean emailCheck(HashMap<String, Object> hm) throws Exception;

	public boolean emailCheck2(HashMap<String, Object> hm) throws Exception;

	public String authKeyCheck(HashMap<String, Object> hm) throws Exception;	
	
}
