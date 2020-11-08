"""
import cv2
cap = cv2.VideoCapture("rtsp://admin:sunnycamel2333@192.168.1.108/Streaming/Channels/1")
ret, frame = cap.read()
while ret:
    ret, frame = cap.read()
    cv2.imshow("frame",frame)
    if cv2.waitKey(1) & 0xFF == ord('q'):
        break
cv2.destroyAllWindows()
cap.release()
"""


# DEMO

import cv2
import os
sourceFileName='star'#
times=0#
outPutDirName='vedio/'+sourceFileName+'/'#

cap = cv2.VideoCapture("rtsp://admin:sunnycamel2333@192.168.1.108/Streaming/Channels/1")
#
#fourcc = cv2.VideoWriter_fourcc(*'MJPG')  # 确定解码器
#out = cv2.VideoWriter('save_elements2.mp4', fourcc, 20.0, (640,  480))
#

# 历史帧
oldFrame = 0.0     # float类型

print("开始")
while True:
	times+=1 #
	ret, frame = cap.read()
	# 当前帧的位置
	frameTag = cap.get(0)
	try:
		# 未获得帧
		if not ret:
			cap.release()
			cv2.destroyAllWindows()
			cap = cv2.VideoCapture("rtsp://admin:sunnycamel2333@192.168.1.108/Streaming/Channels/1")
			ret,frame = cap.read()
		# 相机卡帧（一直卡在同一帧上）:
		if (oldFrame == frameTag) and (oldFrame != 0.0):
			cap.release()
			cv2.destroyAllWindows()
			cap = cv2.VideoCapture("rtsp://admin:sunnycamel2333@192.168.1.108/Streaming/Channels/1")
			ret,frame = cap.read()
		if ret:
			oldFrame = frameTag   # 成为历史帧
			#out.write(frame)  # 存储帧图像——依次存入每一帧获取的图像
			cv2.imshow("Camera", frame)
			cv2.imwrite(outPutDirName + str(times)+'.jpg', frame) #写入帧
			# 如果是waiteKey(0)就会一直等待
			if cv2.waitKey(1) & 0xFF == ord('q'):
				break

	except Exception:
		print("error")
#cap.release()  # 先释放视频捕获
#out.release()   # 再释放存储对象的释放
#cv2.destroyAllWindows()
