package a.a.a.dao;

import java.util.HashMap;

import org.springframework.stereotype.Repository;

import a.a.a.dao.AbstractDAO;

@Repository("membershipDAO")
public class MembershipDAO extends AbstractDAO {

	public HashMap<String, Object> selectMembershipSearch(HashMap<String, Object> hm) {

		return (HashMap<String, Object>) selectOne("memberSearch.selectMembershipSearch", hm);

	}

	

	public void insertMembership(HashMap<String, Object> hm) {

		insert("memberSearch.insertMembership", hm);
	}



	public HashMap<String, Object> selectMembership(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) selectOne("memberSearch.selectMembership", hm);
	}



	public void changePW(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		insert("memberSearch.changePw", hm);
	}



	public void updateMembership(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("memberSearch.updateMembership", hm);
	}



	public HashMap<String, Object> selectMembershipId(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) selectOne("memberSearch.selectMembershipId", hm);
	}


	//회원 탈퇴
	public void memeberDelete(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("memberSearch.deleteMembership", hm);
	}

}
