package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import a.a.a.util.PagingVO;

public interface AdminService {

	public ArrayList<HashMap<String, Object>> adminMembershipList(PagingVO vo) throws SQLException;

	public Object adminBoardList(PagingVO vo) throws SQLException;	
	
	public ArrayList<HashMap<String, Object>> adminBoardListFB(PagingVO vo) throws SQLException;

	public ArrayList<HashMap<String, Object>> adminBoardListPRV(PagingVO vo) throws SQLException;

	public ArrayList<HashMap<String, Object>> adminBoardListQB(PagingVO vo) throws SQLException;

	public ArrayList<HashMap<String, Object>> adminBoardListNB(PagingVO vo) throws SQLException;

	public void restoreFB(HashMap<String, Object> hm) throws SQLException;

	public void restorePRV(HashMap<String, Object> hm) throws SQLException;
 
	public void restoreQB(HashMap<String, Object> hm) throws SQLException;

	public void restoreNB(HashMap<String, Object> hm) throws SQLException;

	public void restoreMembership(HashMap<String, Object> hm) throws SQLException;

	public int countList(HashMap<String, Object> hm) throws SQLException;

	public int countListFB(HashMap<String, Object> hm) throws SQLException;

	public int countListPRV(HashMap<String, Object> hm) throws SQLException;

	public int countListQB(HashMap<String, Object> hm) throws SQLException;

	public int countListNB(HashMap<String, Object> hm) throws SQLException;

	public int countMembership(HashMap<String, Object> map) throws SQLException;

	public HashMap<String, Object> adminSelectMembership(HashMap<String, Object> hm) throws SQLException;

	


}
