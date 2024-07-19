package a.a.a.impl;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import a.a.a.dao.CommonDAO;
import a.a.a.dao.ProjectDAO;
import a.a.a.service.ProjectService;




@Service("projectService")
public class ProjectImpl implements ProjectService {

	@Resource(name="projectDAO")
	private ProjectDAO projectDAO;
	
	@Resource(name="commonDAO")
	private CommonDAO commonDAO;
	
	@Override
	public boolean insertnewcontent(HashMap<String, Object> hm) throws SQLException {
		
		int i = projectDAO.insertnewcontent(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	
	@Override
	public boolean inserttag(HashMap<String, Object> hm) throws SQLException {
		
		int i = projectDAO.inserttag(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	@Override
	public boolean deletetag(HashMap<String, Object> hm) throws SQLException {
		

		int i = projectDAO.deletetag(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	@Override
	public ArrayList<HashMap<String, Object>> gettag(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.gettag(hm);
	}
	
	
	
	@Override
	public int selectseq() throws SQLException {
		
		return projectDAO.selectseq();
	}
	
	
	@Override
	public ArrayList<HashMap<String, Object>> getList(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.getList(hm);
	}
	
	@Override
	public boolean updateViewCnt(HashMap<String, Object> hm) throws SQLException {
		
		int i = projectDAO.updateViewCnt(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	
	
	@Override
	public boolean uploadfile(HashMap<String, Object> hm) throws SQLException {
		
		int i = projectDAO.uploadfile(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	
	@Override
	public boolean removeimg(HashMap<String, Object> hm) throws SQLException {
		

		int i = projectDAO.removeimg(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}

	@Override
	public ArrayList<HashMap<String, Object>> getChkFileCnt(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.getChkFileCnt(hm);
	}
	
	@Override
	public ArrayList<HashMap<String, Object>> getFileInfo(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.getFileInfo(hm);
	}
	
	
	@Override
	public ArrayList<HashMap<String, Object>> selectseqperplan(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.selectseqperplan(hm);
	}
	
	
	@Override
	public boolean insertRoute(HashMap<String, Object> hm) throws SQLException {
		
		int i = projectDAO.insertRoute(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	

	
	@Override
	public ArrayList<HashMap<String, Object>> selectRoute(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.selectRoute(hm);
	}
	
	
	
	
	
	@Override
	public boolean deleteBookmarkRoute(HashMap<String, Object> hm) throws SQLException {
		

		int i = projectDAO.deleteBookmarkRoute(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	
	@Override
	public ArrayList<HashMap<String, Object>> selectbookmarkseq(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.selectbookmarkseq(hm);
	}
	
	
	@Override
	public boolean insertBookmark(HashMap<String, Object> hm) throws SQLException {
		
		int i = projectDAO.insertBookmark(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	
	@Override
	public ArrayList<HashMap<String, Object>> selectBMRoute1(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.selectBMRoute1(hm);
	}
	
	@Override
	public ArrayList<HashMap<String, Object>> selectBMRoute2(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.selectBMRoute2(hm);
	}
	
	
	
	@Override
	public boolean insertTravelRoute(HashMap<String, Object> hm) throws SQLException {
		
		int i = projectDAO.insertTravelRoute(hm);
		boolean bol = false;
		
		System.out.println("i = " + i);
		
		if(i != 0) {
			bol = true;
		} else {
			bol = false;
		}
		
		return bol;
	}
	
	@Override
	public ArrayList<HashMap<String, Object>> selectRouteTR(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.selectRouteTR(hm);
	}
	
	@Override
	public ArrayList<HashMap<String, Object>> getMaxTrday(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.getMaxTrday(hm);
	}
	
	@Override
	public ArrayList<HashMap<String, Object>> getListfromTag(HashMap<String, Object> hm) throws SQLException {
		
		return projectDAO.getListfromTag(hm);
	}
	
}
