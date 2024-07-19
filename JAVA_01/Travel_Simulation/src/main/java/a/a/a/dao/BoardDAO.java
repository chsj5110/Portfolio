package a.a.a.dao;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;

import a.a.a.util.PagingVO;

@Repository("boardDAO")
public class BoardDAO extends AbstractDAO{
	//리뷰 미리보기
	public HashMap<String, Object> selectReviewListCnt() {
		return (HashMap<String, Object>) selectOne("board.selectReviewListCnt");
	}
	
	public ArrayList<HashMap<String, Object>> selectReviewPreview() throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.selectReviewPreview");
	}
	public int insertPreview(HashMap<String, Object> hm) throws SQLException {
		return (Integer) insert("board.insertPreview", hm);
	}
	
	//리뷰
	public HashMap<String, Object> ReviewListCnt(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("board.ReviewListCnt", hm);
	}
	public ArrayList<HashMap<String, Object>> selectReview(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.selectReview", hm);
	}
	
	//추천 저장된 장소 불러오기
	public  ArrayList<HashMap<String, Object>> reviewRCMlist(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.reviewRCMlist", hm);
	}
	public HashMap<String, Object> placeinfo(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("board.placeinfo", hm);
	}
	
	//리뷰글 작성
	public HashMap<String, Object> insertRegisterSEQ() {
		return (HashMap<String, Object>) selectOne("board.insertRegisterSEQ");
	}
	
	public HashMap<String, Object> reviewSEQ() {
		return (HashMap<String, Object>) selectOne("board.reviewSEQ");
	}
	
	public int insertRegister(HashMap<String, Object> hm) throws SQLException{
		return (Integer) insert("board.insertRegister", hm);
	}
	
	//수정
	public HashMap<String, Object> modifyData(HashMap<String, Object> mfb) throws SQLException{
		return (HashMap<String, Object>) selectOne("board.modifyData", mfb);
	}

	public int updatemodify(HashMap<String, Object> upmfb) throws SQLException{
		return (Integer) update("board.updatemodify", upmfb);
	}
	
	//평점 올리기
	public int updategrade(HashMap<String, Object> hm) throws SQLException{
		return (Integer) update("board.updategrade", hm);
	}
	
	public HashMap<String, Object> avgGrade(HashMap<String, Object> hm) throws SQLException{
		// TODO Auto-generated method stub
		return (HashMap<String, Object>) selectOne("board.avgGrade", hm);
	}
	
	public int updateAvg(HashMap<String, Object> hm) throws SQLException{
		return (Integer) update("board.updateAvg", hm);
	}

	//평점 가져오기
	public ArrayList<HashMap<String, Object>> selectgrade(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.selectgrade", hm);
	}
	
	//평점 조회
	public HashMap<String, Object> viewgrade(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("board.viewgrade", hm);
	}

	//전체 게시글 수
	public int countPRV(PagingVO vo) {
		// TODO Auto-generated method stub
		return (int) selectOne("board.countPRV",vo);
	}
	
	
	//페이징 처리후 게시글 목록 출력
	public ArrayList<HashMap<String, Object>> selectPRV(PagingVO vo) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("board.selectPRV",vo);
	}

	
	//게시글 삭제
	public void deleteRB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		update("board.rbDelete", hm);
	}
	
	//나의 추천여행리스트 불러오기
	public ArrayList<HashMap<String, Object>> tripList(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.tripList", hm);
	}

	public ArrayList<HashMap<String, Object>> RCMplacelist(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.RCMplacelist", hm);
	}

	public HashMap<String, Object> RCMplaceLatLng(HashMap<String, Object> hm) throws SQLException{
		return (HashMap<String, Object>) selectOne("board.RCMplaceLatLng", hm);
	}

	public ArrayList<HashMap<String, Object>> SelectionplaceLatLng(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.SelectionplaceLatLng", hm);
	}

	public ArrayList<HashMap<String, Object>> bookmarkselect(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.bookmarkselect", hm);
	}
	public ArrayList<HashMap<String, Object>> bookmarkinfo(HashMap<String, Object> hm) throws SQLException{
		return (ArrayList<HashMap<String, Object>>) selectList("board.bookmarkinfo", hm);
	}

	public void addViews(int index) {
		update("board.addViews", index);
		
	}


}
