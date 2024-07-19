package a.a.a.dao;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

@Repository("projectDAO")
public class ProjectDAO extends AbstractDAO{

	public int insertnewcontent(HashMap<String, Object> hm){
		
		return (Integer) insert("project.insertnewcontent", hm);		
		
	}
	
	public int inserttag(HashMap<String, Object> hm){
	
	return (Integer) insert("project.inserttag", hm);		
	
	}

	public int deletetag(HashMap<String, Object> hm) throws SQLException{
	
	return (Integer) insert("project.deletetag", hm);		
	
	}

	public ArrayList<HashMap<String, Object>> gettag(HashMap<String, Object> hm) {
	
	return (ArrayList<HashMap<String, Object>>) selectList("project.gettag", hm);
	}
	
	public int selectseq() {
		
		return (Integer) selectOne("project.selectseq");
	}
	
	public ArrayList<HashMap<String, Object>> getList(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.getList", hm);
	}
	
	public int updateViewCnt(HashMap<String, Object> hm){
		
		return (Integer) insert("project.updateViewCnt", hm);		
		
		}
	
	
	
	
	public int uploadfile(HashMap<String, Object> hm){
		
		System.out.println("=================");
		System.out.println(hm);
		return (Integer) insert("project.uploadfiles", hm);		
		
	}
	
	public int removeimg(HashMap<String, Object> hm) throws SQLException{
		
		return (Integer) insert("project.deleteimg", hm);		
		
	}

	
	public ArrayList<HashMap<String, Object>> getChkFileCnt(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.getChkFileCnt", hm);
	}
	
	public ArrayList<HashMap<String, Object>> getFileInfo(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.getFileInfo", hm);
	}
	
	public ArrayList<HashMap<String, Object>> selectseqperplan(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.selectseqperplan", hm);
		}
	
	public int insertRoute(HashMap<String, Object> hm){
	
	return (Integer) insert("project.insertRoute", hm);		
	
	}
	
	public ArrayList<HashMap<String, Object>> selectRoute(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.selectRoute", hm);
	}
	
	
	
	public int deleteBookmarkRoute(HashMap<String, Object> hm) throws SQLException{
		
		return (Integer) insert("project.deleteBookmarkRoute", hm);		
		
		}
	
	
	public ArrayList<HashMap<String, Object>> selectbookmarkseq(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.selectbookmarkseq", hm);
		}
	
	public int insertBookmark(HashMap<String, Object> hm){
	
	return (Integer) insert("project.insertBookmark", hm);		
	
	}
	
	
	public ArrayList<HashMap<String, Object>> selectBMRoute1(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.selectBMRoute1", hm);
	}
	
	public ArrayList<HashMap<String, Object>> selectBMRoute2(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.selectBMRoute2", hm);
	}
	
	public int insertTravelRoute(HashMap<String, Object> hm){
		
		return (Integer) insert("project.insertTravelRoute", hm);		
		
		}
	
	public ArrayList<HashMap<String, Object>> selectRouteTR(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.selectRouteTR", hm);
	}
	
	public ArrayList<HashMap<String, Object>> getMaxTrday(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.getMaxTrday", hm);
	}
	
	public ArrayList<HashMap<String, Object>> getListfromTag(HashMap<String, Object> hm) {
		
		return (ArrayList<HashMap<String, Object>>) selectList("project.getListfromTag", hm);
	}
	
}
