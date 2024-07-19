package a.a.a.impl;

import java.sql.SQLException;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.MembershipDAO;
import a.a.a.service.MembershipService;



@Service("membershipService")
public class MembershipImpl implements MembershipService{

	
	@Resource(name="membershipDAO")
    private MembershipDAO membershipDAO;

	@Override
	public boolean selectMembershipSearch(HashMap<String, Object> hm) throws SQLException {
			
		int i = Integer.parseInt(membershipDAO.selectMembershipSearch(hm).get("CNT").toString());
		boolean bol = false;
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	
	
	@Override
	public void insertMembership(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		membershipDAO.insertMembership(hm);
	}



	@Override
	public HashMap<String, Object> selectMembership(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) membershipDAO.selectMembership(hm);
	}


	//비밀번호 변경
	@Override
	public void changePw(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		membershipDAO.changePW(hm);
	}


	//회원정보 수정
	@Override
	public void updateMembership(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		membershipDAO.updateMembership(hm);
	}


	//회원 아이디 찾기
	@Override
	public HashMap selectMembershipId(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) membershipDAO.selectMembershipId(hm);
	}



	@Override
	public void memeberDelete(HashMap<String, Object> hm) throws SQLException {
		// TODO Auto-generated method stub
		membershipDAO.memeberDelete(hm);
	}

    
}
