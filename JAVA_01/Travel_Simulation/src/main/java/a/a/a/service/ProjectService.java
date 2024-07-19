package a.a.a.service;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

public interface ProjectService {
	public boolean insertnewcontent(HashMap<String, Object> hm) throws SQLException;
	
	public boolean inserttag(HashMap<String, Object> hm) throws SQLException;

	public boolean deletetag(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> gettag(HashMap<String, Object> hm) throws SQLException;

	public int selectseq() throws SQLException;
	
	public ArrayList<HashMap<String, Object>> getList(HashMap<String, Object> hm) throws SQLException;
	
	public boolean updateViewCnt(HashMap<String, Object> hm) throws SQLException;

	public boolean uploadfile(HashMap<String, Object> hm) throws SQLException;

	public boolean removeimg(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> getChkFileCnt(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> getFileInfo(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> selectseqperplan(HashMap<String, Object> hm) throws SQLException;
	
	public boolean insertRoute(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> selectRoute(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> selectbookmarkseq(HashMap<String, Object> hm) throws SQLException;
	
	public boolean deleteBookmarkRoute(HashMap<String, Object> hm) throws SQLException;
	
	public boolean insertBookmark(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> selectBMRoute1(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> selectBMRoute2(HashMap<String, Object> hm) throws SQLException;
	
	public boolean insertTravelRoute(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> selectRouteTR(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> getMaxTrday(HashMap<String, Object> hm) throws SQLException;
	
	public ArrayList<HashMap<String, Object>> getListfromTag(HashMap<String, Object> hm) throws SQLException;
	
}
