package a.a.a.service;


import java.sql.SQLException;
import java.util.HashMap;

public interface MembershipService {
	
	public boolean selectMembershipSearch(HashMap<String, Object> hm) throws SQLException;
	
	

	public void insertMembership(HashMap<String, Object> hm) throws SQLException;



	public HashMap<String,Object> selectMembership(HashMap<String, Object> hm) throws SQLException;



	public void changePw(HashMap<String, Object> hm) throws SQLException;



	public void updateMembership(HashMap<String, Object> hm) throws SQLException;



	public HashMap selectMembershipId(HashMap<String, Object> hm) throws SQLException;



	public void memeberDelete(HashMap<String, Object> hm) throws SQLException;
	
}
