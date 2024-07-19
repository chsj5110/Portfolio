package a.a.a.dao;

import java.util.ArrayList;
import java.util.HashMap;

import org.springframework.stereotype.Repository;



@Repository("commentDAO")
public class CommentDAO extends AbstractDAO {

//자유게시글 댓글
	//댓글 등록
	public void insertCommentFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		insert("comment.insertCommentFB", hm); 
		update("comment.updateCommentCount", hm);
	}
	
	//댓글 목록 출력
	public ArrayList<HashMap<String, Object>> commentListFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("comment.commentListFB",hm);
	}
	
	//댓글 삭제
	public void deleteComment(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
	
		update("comment.deleteComment", hm); 
		update("comment.updateCommentCount", hm);
	}

	//댓글수 조회
	public Integer countCommentFB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (Integer) selectOne("comment.countComment",hm);
	}	
	
	
	
	
//리뷰 게시글 댓글	
	//댓글 등록
	public void insertCommentRB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		insert("comment.insertCommentRB", hm); 
	}
	
	//댓글 목록 출력
	public ArrayList<HashMap<String, Object>> commentListRB(HashMap<String, Object> hm) {
		// TODO Auto-generated method stub
		return (ArrayList<HashMap<String, Object>>) selectList("comment.commentListRB",hm);
	}	
}
