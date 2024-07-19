package a.a.a.dao;

import java.util.HashMap;
import java.util.Map;

import org.springframework.stereotype.Repository;

@Repository("mailDAO")
public class MailDAO extends AbstractDAO {


	public void createAuthKey(String userEmail, String authKey) throws Exception { // 인증키 DB에 넣기
		Map<String, Object> map = new HashMap<String, Object>();

		map.put("userEmail", userEmail);
		map.put("authKey", authKey);

		insert("mail_auth.createAuthKey", map);
	}
	
	public void updateAuthKey(String userEmail, String authKey) throws Exception { // 인증키 DB에 넣기
		Map<String, Object> map = new HashMap<String, Object>();

		map.put("userEmail", userEmail);
		map.put("authKey", authKey);

		update("mail_auth.updateAuthKey", map);
	}



	
	public HashMap<String,Object> emailCheck(HashMap<String, Object> hm) throws Exception { // 인증키 일치시 DB칼럼(인증여부) false->true 로 변경
		return (HashMap<String, Object>) selectOne("mail_auth.mail_check", hm);
	}

	public HashMap<String,Object> emailCheck2(HashMap<String, Object> hm) throws Exception { // 인증키 일치시 DB칼럼(인증여부) false->true 로 변경
		return (HashMap<String, Object>) selectOne("mail_auth.mail_check2", hm);
	}
	
	public HashMap<String,Object> authKeyCheck(HashMap<String, Object> hm) throws Exception { // 인증키 일치시 DB칼럼(인증여부) false->true 로 변경
		return (HashMap<String, Object>) selectOne("mail_auth.authKey_check", hm);
	}

}