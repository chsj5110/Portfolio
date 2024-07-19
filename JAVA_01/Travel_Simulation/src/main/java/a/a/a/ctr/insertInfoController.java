package a.a.a.ctr;

import java.io.File;
import java.security.Principal;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.UUID;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;
import a.a.a.service.PlaceService;
import a.a.a.util.CommonInfo;

@Controller
public class insertInfoController {
	private ModelAndView isif = new ModelAndView();
	private ModelAndView mak = new ModelAndView();
	private ModelAndView inrcm = new ModelAndView();
	private ModelAndView rc = new ModelAndView();
	private ModelAndView mytrip = new ModelAndView();
	private ModelAndView mv = new ModelAndView();
	private ModelAndView fi = new ModelAndView();
	

	
	@Resource(name = "placeService")
	private PlaceService placeService;
	
	private static final Logger logger = LoggerFactory.getLogger(MailController.class);
	
	@RequestMapping(value = "/adminIntest.do")
	public String insertInfotest() {
		return "insertInfo/insertInfo_test";
	}
	@RequestMapping(value = "/ui.do")
	public String ui() {
		return "insertInfo/UItest";
	}
	
	@RequestMapping(value = "/insertInfo/insertinfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertinfo(@RequestBody HashMap<String, Object> hm) throws SQLException{
		
		try {
			isif.setViewName("jsonView");
			isif.addObject("inserinfo", placeService.insertinfo(hm));

				logger.info("_____________________________");
				logger.info("insertinfo hm ==" + hm );
				logger.info("insertinfo isif ==" + isif );
				logger.info("_____________________________");
				isif.addObject("success", "Y");
				
		} catch(Exception e) {
			e.printStackTrace();
			isif.addObject("success", "N");
		}

		return isif;
	}
	
	@RequestMapping(value = "/insertInfo/Placemarker.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView markerinfo(@RequestBody HashMap<String, Object> hm) throws SQLException{
		mak.setViewName("jsonView");
		
		mak.addObject("CTYCode", placeService.countryCode(hm));
		ArrayList<HashMap<String, Object>> Marker = placeService.markerinfo(hm);
		mak.addObject("marker", Marker);
			logger.info("_____________________________");
			logger.info("CTYCode ==" + hm );
			logger.info("Markerinfo mak ==" + mak );
			logger.info("_____________________________");
		return mak;
	}
	
	@RequestMapping(value = "/insertInfo/Placerecomm.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView Placerecomm(@RequestBody HashMap<String, Object> hm) throws SQLException{
		rc.setViewName("jsonView");
		
		rc.addObject("placeimg", placeService.placeimg(hm));
		logger.info("_____________________________");
		logger.info("recommInfo ==" + hm );
		logger.info("recommpname ==" + rc );
		logger.info("_____________________________");

		return rc;
	}
	
	@RequestMapping(value = "/likePlace.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView likePlace(@RequestBody HashMap<String, Object> hm, Principal principal) throws SQLException{
		mv.setViewName("jsonView");
		
		if(principal != null) {
		
			String user_id = principal.getName();
			logger.info("principal은"+principal);
			hm.put("userID", user_id);
			
			mv.addObject("recommpname", placeService.recommpname(hm));
			logger.info("_____________________________");
			logger.info("recommInfo ==" + hm );
			logger.info("recommpname ==" + mv );
			logger.info("_____________________________");
		} else {
			mv.addObject("recommpname", "0");
		}
		return mv;
	}
	
	
	@RequestMapping(value = "/insertInfo/recomm.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertrecomm(@RequestBody HashMap<String, Object> hm, Principal principal) throws SQLException{
		inrcm.setViewName("jsonView");
		
		String user_id = principal.getName();
		hm.put("userID", user_id);
		
		logger.info("_____________________________");
		logger.info("recomm hm == "+ hm);
		logger.info("_____________________________");
		
		boolean bol = placeService.recommchk(hm);
		logger.info("1�� bol = "+bol);
		if (bol == true) {
				logger.info("RECOMM = " + hm.get("RECOMM"));
				logger.info("myTrip = " + hm.get("myTrip"));
				placeService.recommupdate(hm);
				inrcm.addObject("RECOMM", hm.get("RECOMM"));
				inrcm.addObject("myTrip", hm.get("myTrip"));
		} else {
			placeService.insertrecomm(hm);
			logger.info("recomm insert = " + hm.get("PNAME"));
			inrcm.addObject("insertrecomm","recomm insert");
		}		

		logger.info("_____________________________");
		logger.info("P_NAME ==" + hm );
		logger.info("inrcm ==" + inrcm );
		logger.info("_____________________________");
		return inrcm;
	}
	
	@RequestMapping(value = "/insertInfo/mytrip.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView mytriplist(@RequestBody HashMap<String, Object> hm, Principal principal)throws SQLException{
		mytrip.setViewName("jsonView");
		
		String user_id = principal.getName();
		hm.put("userID", user_id);
		ArrayList<HashMap<String, Object>> mytriplist = placeService.mytriplist(hm);
		mytrip.addObject("mytriplist", mytriplist);
		
		logger.info("_____________________________");
		logger.info("U_ID ==" + hm );
		logger.info("mytrip ==" + mytrip );
		logger.info("_____________________________");
		return mytrip; 
	}
	
	@RequestMapping(value = "/insertInfo/myTripdel.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView myTripdel(@RequestBody HashMap<String, Object> hm, Principal principal)throws SQLException{
		mytrip.setViewName("jsonView");
		
		String user_id = principal.getName();
		hm.put("userID", user_id);
		placeService.myTripdel(hm);
		
		logger.info("_____________________________");
		logger.info("U_ID ==" + hm );
		logger.info("myTripdel ==" + mytrip );
		logger.info("_____________________________");
		return mytrip; 
		
	}

	//area_info에 여행지 이미지,정보 추가
	@RequestMapping(value = "/insertAreaInfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView upload(@RequestParam(value="uploadFile") MultipartFile[] upload,
								@RequestParam(value="place_name") String place_name,
								@RequestParam(value="img_content") String img_content,
								@RequestParam(value="img_contry_code") String img_contry_code,
								@RequestParam(value="img_city") String img_city,
								@RequestParam(value="img_contry") String img_contry,
								HttpServletRequest request) throws SQLException {
		
		try {
			fi.setViewName("jsonView");
			String uploadFolder = "\\\\192.168.0.119\\travel_simulator_upload\\";
			logger.info("uploadFolder: "+uploadFolder);
			logger.info("upload.length는 "+upload.length);
			
			
			for(int i=0; i<upload.length; i++) {
				MultipartFile File = upload[i];
				String uuid = UUID.randomUUID().toString();	
				String uploadFileName = uuid+File.getOriginalFilename(); 
				int img_rep= i+1;
				double size=(File.getSize()/1024.0)/1024.0;
				String img_size=String.valueOf(size)+"Mb";
				
				HashMap<String,Object> map = new HashMap<String,Object>();
				map.put("img_name", uploadFileName);
				map.put("place_name", place_name);
				map.put("img_content", img_content);
				map.put("img_contry_code", img_contry_code);
				map.put("img_city", img_city);
				map.put("img_contry", img_contry);
				map.put("img_rep", img_rep);
				map.put("img_size", img_size);
				
				logger.info("입력값은"+map);
				
				//데이터 베이스에 이미지 정보 저장
				placeService.insertAreaInfo(map);
				
				//파일 저장을 위한 참조변수
				File saveFile = new File(uploadFolder, uploadFileName);
				
				//경로비교를 위한 참조변수
				File checkPath = new File(uploadFolder.toString());
				
				if(checkPath.isDirectory()==true) {
					((MultipartFile) File).transferTo(saveFile);
					logger.info("디렉토리가 존재합니다.");
				} else {
					//경로에 경로값과 파일이 없다면
					if(!checkPath.exists()) {
						//폴더를 생성
						checkPath.mkdirs();
					}
					((MultipartFile) File).transferTo(saveFile);
					logger.info("디렉토리가 없습니다.");
				}
			}				
			fi.addObject("success","Y");
			
		} catch(Exception e) {
			e.printStackTrace();
			fi.addObject("success","N");
		} // try문 종료			
		
		logger.info("fi는"+fi);
		return fi;
	}
	
	
	
	
	//게시글 삭제
	@RequestMapping(value = "/deletePlaceInfo.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deletePlaceInfo(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("게시글 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		placeService.deletePlaceInfo(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
}
